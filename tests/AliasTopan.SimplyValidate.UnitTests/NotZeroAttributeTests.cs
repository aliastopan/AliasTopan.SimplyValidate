using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class NotZeroAttributeTests
{
    [Test]
    [Arguments(1)]
    [Arguments(-1)]
    public async Task Object_WithValidNotZeroAttribute_ShouldPassValidation(int number)
    {
        // Arrange
        var model = new NotZeroModelTest
        {
            Value = number
        };

        // Act
        bool isValid = model.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    [Arguments(0)]
    public async Task Object_WithInvalidNotZeroAttribute_ShouldPassValidation(int number)
    {
        // Arrange
        var model = new NotZeroModelTest
        {
            Value = number
        };

        // Act
        bool isValid = model.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
