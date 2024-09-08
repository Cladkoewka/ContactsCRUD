using Contacts.API.Contracts;
using Contacts.Core.Models;
using Contacts.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contact>> GetContact(int id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult> CreateContact([FromBody] CreateContactRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var contact = new Contact
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone
        };

        await _contactService.AddContactAsync(contact);
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateContact(int id, [FromBody] UpdateContactRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingContact = await _contactService.GetContactByIdAsync(id);
        if (existingContact == null)
        {
            return NotFound();
        }
            
        var contact = new Contact
        {
            Id = id,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone
        };
        

        await _contactService.UpdateContactAsync(contact);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteContact(int id)
    {
        var existingContact = await _contactService.GetContactByIdAsync(id);
        if (existingContact == null)
        {
            return NotFound();
        }
        
        await _contactService.DeleteContactAsync(id);
        return NoContent();
    }
}