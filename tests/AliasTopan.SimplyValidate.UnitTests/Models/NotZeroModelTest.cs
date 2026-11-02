using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class NotZeroModelTest
{
    [NotZero]
    public int Value { get; set; }
}
