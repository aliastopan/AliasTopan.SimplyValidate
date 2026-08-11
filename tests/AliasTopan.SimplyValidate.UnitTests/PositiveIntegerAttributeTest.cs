using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class PositiveIntegerAttributeTest
{
    [Test]
    public async Task Object_WithValidPositiveIntegerAttribute_ShouldPassValidation()
    {
        // Arrange
        var testKit = new PositiveIntegerModelTest
        {
            Quantity = 1
        };

        // Act
        bool isValid = testKit.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidPositiveIntegerAttribute_ShouldPassValidation()
    {
            // Arrange
        var testKit = new PositiveIntegerModelTest
        {
            Quantity = -1
        };

        // Act
        bool isValid = testKit.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
