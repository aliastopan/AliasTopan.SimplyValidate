using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class ParsableEnumAttributeTests
{
    [Test]
    public async Task Object_WithValidParsableEnumAttribute_ShouldPassValidation()
    {
        // Arrange
        var json = new OrderJson
        {
            OrderStatus = "Processing"
        };

        // Act
        bool isValid = json.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidMustBeAttribute_ShouldFailValidation()
    {
        // Arrange
        var json = new OrderJson
        {
            OrderStatus = "invalid_enum_value"
        };

        // Act
        bool isValid = json.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
