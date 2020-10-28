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

public class HeadquarterController : ControllerBase{
private readonly SchoolContext _context;

public HeadquarterController(SchoolContext context)
{
    _context = context;
}

[HttpGet]
    public async Task<ActionResult<IEnumerable<HeadquarterEntity>>> GetHeadquarters()
    {
        return await _context.HeadquarterItems
            .Select(x => headquarterDTO(x))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HeadquarterEntity>> GetHeadquarter(long id)
    {
        var headquarterItem = await _context.HeadquarterItems.FindAsync(id);

        if (headquarterItem == null)
        {
            return NotFound();
        }

        return headquarterDTO(headquarterItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHeadquarter(long id, HeadquarterEntity headquarterItem)
    {
        if (id != headquarterItem.Id)
        {
            return BadRequest();
        }

        var headquarter = await _context.HeadquarterItems.FindAsync(id);
        if (headquarter == null)
        {
            return NotFound();
        }

        headquarter.Name = headquarterItem.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!HeadquarterExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }
//https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code
    
    [HttpPost]
    public async Task<ActionResult<HeadquarterEntity>> CreateHeadquarter(NewHeadquarterEntityDTO headquarterItem)
    {
        var headquarter = new HeadquarterEntity
        {
            Name = headquarterItem.Name,
        
        };

        _context.HeadquarterItems.Add(headquarter);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetHeadquarter),
            new { id = headquarter.Id },
            headquarterDTO(headquarter));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHeadquarter(long id)
    {
        var headquarter = await _context.HeadquarterItems.FindAsync(id);

        if (headquarter == null)
        {
            return NotFound();
        }

        _context.HeadquarterItems.Remove(headquarter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HeadquarterExists(long id) =>
         _context.HeadquarterItems.Any(e => e.Id == id);

    private static HeadquarterEntity headquarterDTO(HeadquarterEntity headquarterItem) =>
        new HeadquarterEntity
        {
            Id = headquarterItem.Id,
            Name = headquarterItem.Name,
        };       

    }
}