using System.ComponentModel.DataAnnotations;
using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class PositiveIntegerModelTest
{
    [PositiveInteger]
    public required int Quantity { get; set; }
}


