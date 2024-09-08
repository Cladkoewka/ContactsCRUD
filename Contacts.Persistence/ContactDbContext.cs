using Contacts.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Persistence;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) {}

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasKey(c => c.Id);
    }
}