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

public class ContactController : ControllerBase{
private readonly SchoolContext _context;

public ContactController(SchoolContext context)
{
    _context = context;
}
[HttpGet]
public async Task<ActionResult<IEnumerable<ContactEntity>>> GetContact()
{
    return await _context.ContactItems
        .Select(x => contactDTO(x))
        .ToListAsync();
}
[HttpGet("{id}")]
public async Task<ActionResult<ContactEntity>> GetContact(long id)
{
    var contact = await _context.ContactItems.FindAsync(id);

    if (contact == null)
    {
        return NotFound();
    }

    return contactDTO(contact);
}
 [HttpPost]
    public async Task<ActionResult<ContactEntity>> CreateContact(ContactEntity contactItem)
    {
        var contact = new ContactEntity
        {
            Id = contactItem.Id,
            Name = contactItem.Name,
            Lastname =contactItem.Lastname,
            Email = contactItem.Email,
            PhoneNumber = contactItem.PhoneNumber,
            Content = contactItem.Content,
        };

        _context.ContactItems.Add(contact);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetContact),
            new { id = contact.Id },
            contactDTO(contact));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(long id)
    {
        var contact = await _context.ContactItems.FindAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        _context.ContactItems.Remove(contact);
        await _context.SaveChangesAsync();

        return NoContent();
    }

private bool ContactExists(long id) =>
         _context.ContactItems.Any(e => e.Id == id);

    private static ContactEntity contactDTO(ContactEntity ContactItem) =>
        new ContactEntity
        {
            Id = ContactItem.Id,
            Name = ContactItem.Name,
            Lastname =ContactItem.Lastname,
            Email = ContactItem.Email,
            PhoneNumber = ContactItem.PhoneNumber,
            Content = ContactItem.Content,
        };       
    }


}