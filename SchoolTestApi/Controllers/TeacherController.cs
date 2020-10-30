using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Controllers{

    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase{
         private readonly SchoolContext _context;

         public TeacherController(SchoolContext context)
        {
        _context = context;
        }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherEntity>>> GetTeachers()
    {
        return await _context.TeachersItems
            .Select(x => teacherDTO(x))
            .ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherEntity>> GetTeachers(int id)
    {
        var teacherItem = await _context.TeachersItems.FindAsync(id);

        if (teacherItem == null)
        {
            return NotFound();
        }

        return teacherDTO(teacherItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, TeacherEntity teachertItem)
    {
        if (id != teachertItem.Id)
        {
            return BadRequest();
        }

        var teacher = await _context.TeachersItems.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        teacher.Name = teachertItem.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TeacherExists(id))
        {
            return NotFound();
        }
    

        return NoContent();
    }
    
    [HttpPost]
    public async Task<ActionResult<TeacherEntity>> CreateTeacher(NewTeacherEntityDTO teacherItem)
    {
        var teacher = new TeacherEntity
        {

            
            Name = teacherItem.Name,
            Lastname = teacherItem.Lastname,
            User = teacherItem.User,
            Password = teacherItem.Password,
            Headquarter = teacherItem.Headquarter,
            PhoneNumber = teacherItem.PhoneNumber,
            EmergencyContactName = teacherItem.EmergencyContactName, 
            EmergencyContactNumber = teacherItem.EmergencyContactNumber,
        };

        _context.TeachersItems.Add(teacher);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTeachers),
            new { id = teacher.Id },
            teacherDTO(teacher));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var teacher = await _context.TeachersItems.FindAsync(id);

        if (teacher == null)
        {
            return NotFound();
        }

        _context.TeachersItems.Remove(teacher);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TeacherExists(int id) =>
         _context.TeachersItems.Any(e => e.Id == id);

    private static TeacherEntity teacherDTO(TeacherEntity teacherItem) =>
        new TeacherEntity
        {
            Id = teacherItem.Id,
            Name = teacherItem.Name,
            Lastname = teacherItem.Lastname,
            User = teacherItem.User,
            Headquarter = teacherItem.Headquarter,
            PhoneNumber = teacherItem.PhoneNumber,
            EmergencyContactName = teacherItem.EmergencyContactName, 
            EmergencyContactNumber = teacherItem.EmergencyContactNumber,
        };       
    }
      
}