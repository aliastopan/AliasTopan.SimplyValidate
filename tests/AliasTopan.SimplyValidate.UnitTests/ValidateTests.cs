using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public class ValidateTests
{
    [Test]
    [Arguments("user.name", "p@ss.word012")]
    [Arguments("test_user", "test_pass")]
    [Arguments("aliastopan", "x2gRsix")]
    public async Task Object_WithValidDataAnnotation_ShouldPassValidation(string username, string password)
    {
        // Arrange
        var request = new LoginRequest
        {
            Username = username,
            Password = password
        };

        // Act
        bool isValid = request.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    [Arguments("user.name", "")]
    [Arguments("", "p@ss.word012")]
    [Arguments("", "")]
    public async Task Object_WithInvalidDataAnnotation_ShouldNotPassValidation(string username, string password)
    {
        // Arrange
        var request = new LoginRequest
        {
            Username = username,
            Password = password
        };

        // Act
        bool isValid = request.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
