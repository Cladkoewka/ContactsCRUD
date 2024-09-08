using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Contracts;

public record CreateContactRequest(
    [Required(ErrorMessage = "First name is required.")]
    string FirstName,
    [Required(ErrorMessage = "Last name is required.")]
    string LastName,
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    string Email,
    [Phone(ErrorMessage = "Invalid phone number format.")]
    string Phone);