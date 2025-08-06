using AliasTopan.EitherPattern;
using AliasTopan.SimplyValidate.Errors;
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
            Password = "weak"
        };

        var result = CreateAccount(badRequest);

        result.Match(
            onSuccess: _ => Console.WriteLine("This should not happen."),
            onError: errors => Console.WriteLine($"{errors.MessageVerbose}")
        );

        Console.Write("\n");
    }

    private static void GoodRequestExample()
    {
        Console.WriteLine("Good Request:");

        var goodRequest = new NewAccountRequest
        {
            Username = "aliastopan",
            Email = "topan@example.com",
            Password = "secure_password"
        };

        var result = CreateAccount(goodRequest);

        result.Match(
            onSuccess: _ => Console.WriteLine("Request accepted."),
            onError: _ => Console.WriteLine("This should not happen.")
        );

        Console.Write("\n");
    }

    public static Either<CreateAccountError, Success> CreateAccount(NewAccountRequest request)
    {
        if (!request.ValidateAnnotation(out var annotationErrors))
        {
            CreateAccountError error = new CreateAccountError(annotationErrors);

            return Either<CreateAccountError, Success>.Error(error);
        }

        return Either<CreateAccountError, Success>.Success(Success.Default);
    }
}

public class CreateAccountError : ErrorBase
{
    public CreateAccountError(IReadOnlyCollection<AnnotationError> errors)
        : base(errors)
    {

    }
}
