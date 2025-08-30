using AliasTopan.EitherPattern;
using AliasTopan.SimplyValidate.Abstractions;
using AliasTopan.SimplyValidate.ManualTest.Models;

namespace AliasTopan.SimplyValidate.ManualTest.Tests;

public static class ValidateAnnotationTest
{
    public static void RunTest()
    {
        Console.WriteLine("# _ValidateAnnotationTest_");

        BadRequestExample();
        GoodRequestExample();
    }

    private static void BadRequestExample()
    {
        Console.WriteLine("Bad Request:");

        var badRequest = new NewAccountRequest
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

        var result = CreateAccount(badRequest);

        result.Match(
            onSuccess: _ => Console.WriteLine("This should not happen."),
            onError: errors => Console.WriteLine($"{errors.Message}")
        );

        Console.Write("\n");
    }

    private static void GoodRequestExample()
    {
        Console.WriteLine("Good Request:");

        var goodRequest = new NewAccountRequest
        {
            Username = "johndoe",
            Email = "jd@example.com",
            Password = "secure_password",
            UserInfo = new UserInfo
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(2000,1, 1)
            }
        };

        var result = CreateAccount(goodRequest);

        result.Match(
            onSuccess: _ => Console.WriteLine("Request accepted."),
            onError: _ => Console.WriteLine("This should not happen.")
        );

        Console.Write("\n");
    }

    public static Either<IAccountError, Success> CreateAccount(NewAccountRequest request)
    {
        if (!request.Validate(out IReadOnlyCollection<ValidationError> errors))
        {
            IAccountError error = new CreateAccountError(errors);

            return Either<IAccountError, Success>.Error(error);
        }

        return Either<IAccountError, Success>.Success(Success.Default);
    }
}

public interface IAccountError
{
    public string Message { get; }
}

public class CreateAccountError : AggregateAnnotationError, IAccountError
{
    public override string Message => base.MessageVerbose;

    public CreateAccountError(IReadOnlyCollection<ValidationError> errors)
        : base(errors)
    {

    }
}
