using System.ComponentModel.DataAnnotations;
using AliasTopan.SimplyValidate.DataAnnotations;
using AliasTopan.SimplyValidate.ManualTest.DataAnnotations;

namespace AliasTopan.SimplyValidate.ManualTest.Models;

public class NewAccountRequest
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
    [RegularExpression("^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "A valid email address is required.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [NestedValidate(ErrorMessage = "The {0} field contains invalid data.")]
    public UserInfo UserInfo { get; set; } = new UserInfo();
}

public class UserInfo
{
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of Birth is required.")]
    [AgeRequirement(MinimumAge = 18, ErrorMessage = "You must be at least 18 years old to create an account.")]
    public DateOnly DateOfBirth { get; set; }
}