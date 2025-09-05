using System.ComponentModel.DataAnnotations;
using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class User
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Nested]
    public UserInfo UserInfo { get; set; } = new UserInfo();
}

public class UserInfo
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;
}