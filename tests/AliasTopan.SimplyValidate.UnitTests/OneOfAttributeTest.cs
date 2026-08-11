using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class OneOfAttributeTest
{
    [Test]
    public async Task Object_WithValidOneOfAttribute_ShouldPassValidation()
    {
        // Arrange
        var testKit = new OneOfModelTest
        {
            ApprovalStatus = "approved"
        };

        // Act
        bool isValid = testKit.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidOneOfAttribute_ShouldPassValidation()
    {
        // Arrange
        var testKit = new OneOfModelTest
        {
            ApprovalStatus = "wrong_enum"
        };

        // Act
        bool isValid = testKit.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}

