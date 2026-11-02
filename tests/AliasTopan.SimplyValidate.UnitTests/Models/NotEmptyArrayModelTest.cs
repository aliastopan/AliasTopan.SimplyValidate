using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class NotEmptyArrayModelTest
{
    [NotEmptyArray]
    public required Guid[] ArrayIds { get; set; } = [];
}
