using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Controllers{

    /* Modelo para generacion automatica de controllers
    dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem 
    -dc TodoContext -outDir Controllers*/

    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase{
        private readonly SchoolContext _context;

         public StudentController(SchoolContext context)
        {
        _context = context;
        }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentEntity>>> GetStudents()
    {
        return await _context.StudentItems
            .Select(x => studentDTO(x))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentEntity>> GetStudents(long id)
    {
        var studentItem = await _context.StudentItems.FindAsync(id);

        if (studentItem == null)
        {
            return NotFound();
        }

        return studentDTO(studentItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(long id, StudentEntity studentItem)
    {
        if (id != studentItem.Id)
        {
            return BadRequest();
        }

        var student = await _context.StudentItems.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        student.Name = studentItem.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!StudentExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }
//https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code
    
    [HttpPost]
    public async Task<ActionResult<StudentEntity>> CreateStudent(NewStudentEntityDTO studentItem)
    {
        var student = new StudentEntity
        {
            Name = studentItem.Name,
            Lastname = studentItem.Lastname,
            User = studentItem.User,
            Password = studentItem.Password,
            Headquarter = studentItem.Headquarter,
            PhoneNumber = studentItem.PhoneNumber,
            EmergencyContactName = studentItem.EmergencyContactName, 
            EmergencyContactNumber = studentItem.EmergencyContactNumber,
        };

        _context.StudentItems.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetStudents),
            new { id = student.Id },
            studentDTO(student));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(long id)
    {
        var student = await _context.StudentItems.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        _context.StudentItems.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StudentExists(long id) =>
         _context.StudentItems.Any(e => e.Id == id);

    private static StudentEntity studentDTO(StudentEntity studentItem) =>
        new StudentEntity
        {
            Id = studentItem.Id,
            Name = studentItem.Name,
            Lastname = studentItem.Lastname,
            User = studentItem.User,
            Headquarter = studentItem.Headquarter,
            PhoneNumber = studentItem.PhoneNumber,
            EmergencyContactName = studentItem.EmergencyContactName, 
            EmergencyContactNumber = studentItem.EmergencyContactNumber,
        };       
    }
}