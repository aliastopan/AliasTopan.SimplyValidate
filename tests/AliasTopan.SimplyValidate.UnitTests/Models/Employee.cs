using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class Employee
{
    [NotEmptyGuid]
    public ValueObjectId EmployeeId { get; set; }
}
