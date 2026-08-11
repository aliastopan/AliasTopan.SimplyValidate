using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class Base64AttributeTest
{
    [Test]
    public async Task Object_WithValidBase64Attribute_ShouldPassValidation()
    {
        // Arrange
        var form = new Base64ModelTest
        {
            ImageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNk+A8AAQUBAScY42YAAAAASUVORK5CYII="
        };

        // Act
        bool isValid = form.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidBase64Attribute_ShouldFailValidation()
    {
        // Arrange
        var form = new Base64ModelTest
        {
            ImageBase64 = "not_base64_string"
        };

        // Act
        bool isValid = form.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
