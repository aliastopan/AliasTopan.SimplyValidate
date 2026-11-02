using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class NotEmptyArrayAttributeTests
{
    [Test]
    public async Task Object_WithValidNotEmptyArrayAttribute_ShouldPassValidation()
    {
        // Arrange
        var model = new NotEmptyArrayModelTest
        {
            ArrayIds = [
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            ]
        };

        // Act
        bool isValid = model.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidNotEmptyArrayAttribute_ShouldPassValidation()
    {
        // Arrange
        var model = new NotEmptyArrayModelTest
        {
            ArrayIds = []
        };

        // Act
        bool isValid = model.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
