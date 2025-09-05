using System.ComponentModel.DataAnnotations;
using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class AgreementForm
{
    [Required]
    [MustBeTrue]
    public bool AgreedToTerms { get; set; }
}
