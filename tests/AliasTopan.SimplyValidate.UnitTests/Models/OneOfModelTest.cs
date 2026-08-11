using System.ComponentModel.DataAnnotations;
using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class OneOfModelTest
{
    [OneOf("approved", "rejected")]
    public required string ApprovalStatus { get; set; }
}
