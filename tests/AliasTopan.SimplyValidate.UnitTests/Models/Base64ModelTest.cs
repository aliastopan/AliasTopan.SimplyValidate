using System.ComponentModel.DataAnnotations;
using AliasTopan.SimplyValidate.DataAnnotations;

namespace AliasTopan.SimplyValidate.UnitTests.Models;

public sealed class Base64ModelTest
{
    [Base64]
    public string ImageBase64 { get; set; } = string.Empty;

}
