using AliasTopan.SimplyValidate.ManualTest.Models;

namespace AliasTopan.SimplyValidate.ManualTest.Tests;

public class ValidateWithLogTest
{
    public static void RunTest()
    {
        Console.WriteLine("# _ValidateWithLogTest_");

        var request = new NewAccountRequest
        {
            Username = "e",
            Email = "not-an-email",
            Password = "weak",
            UserInfo = new UserInfo
            {
                FirstName = null!,
                LastName = null!,
                DateOfBirth = DateOnly.FromDateTime(DateTime.Today)
            }
        };

        var isBadRequest = !request.ValidateWithLog(out string jsonErrorLog);

        if (isBadRequest)
            Console.WriteLine(jsonErrorLog);
        else
            throw new NotImplementedException();
    }
}
