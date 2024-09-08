using Contacts.Core.Models;
using Contacts.Persistence.Repositories.Interfaces;

namespace Contacts.Logic.Services;

public class ContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _contactRepository.GetAllContactsAsync();
    }
    
    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        var contact = await _contactRepository.GetContactByIdAsync(id);
        return contact;
    }
    
    public async Task AddContactAsync(Contact contact)
    {
        await _contactRepository.AddContactAsync(contact);
    }
    
    public async Task UpdateContactAsync(Contact contact)
    {
        await _contactRepository.UpdateContactAsync(contact);
    }
    
    public async Task DeleteContactAsync(int id)
    {
        var existingContact = await _contactRepository.GetContactByIdAsync(id);

        await _contactRepository.DeleteContactAsync(id);
    }
}