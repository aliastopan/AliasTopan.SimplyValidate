using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class MustBeTrueAttributeTest
{
    [Test]
    public async Task Object_WithValidMustBeAttribute_ShouldPassValidation()
    {
        // Arrange
        var form = new AgreementForm
        {
            AgreedToTerms = true
        };

        // Act
        bool isValid = form.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidMustBeAttribute_ShouldFailValidation()
    {
        // Arrange
        var form = new AgreementForm
        {
            AgreedToTerms = false
        };

        // Act
        bool isValid = form.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
