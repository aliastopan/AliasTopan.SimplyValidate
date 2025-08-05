using AliasTopan.SimplyValidate.Models;

namespace AliasTopan.SimplyValidate.Tests;

public static class ValidateAnnotationTest
{
    public static void RunTest()
    {
        Console.WriteLine("# _ValidateAnnotationTest_");

        BadRequestExample();
    }

    private static void BadRequestExample()
    {
        var badRequest = new NewAccountRequest
        {
            Username = "e",
            Email = "not-an-email",
            Password = "weak"
        };

        var isValid = badRequest.ValidateAnnotation(out var complianceErrors);

        if (isValid)
        {
            Console.WriteLine("Status Code 200");

            return;
        }

        Console.WriteLine("Status Code 422");

        foreach (var error in complianceErrors)
        {
            Console.WriteLine($" - Member: {error.MemberName}, Error: {error.ErrorMessage}");
        }
    }
}
