using System.Text;
using AliasTopan.EitherPattern;
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
            onError: errors => Console.WriteLine($"{errors.Message}")
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

public record CreateAccountError
{
    public IReadOnlyCollection<AnnotationError> AnnotationErrors { get; init; }
    public string Message => FormatErrorMessage();

    public CreateAccountError(IReadOnlyCollection<AnnotationError> annotationErrors)
    {
        AnnotationErrors = annotationErrors;
    }

    private string FormatErrorMessage()
    {
        if (AnnotationErrors is null || AnnotationErrors.Count is 0)
        {
            return string.Empty;
        }

        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Account creation failed due to the following annotation errors:");

        int i = 1;
        foreach (var error in AnnotationErrors)
        {
            builder.AppendLine($" {i++}. Member: '{error.MemberName}', Reason: {error.ErrorMessage}");
        }

        return builder.ToString();
    }
}
