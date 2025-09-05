using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public class NestedAttributeTests
{
    [Test]
    [Arguments("k.reeves", "Keanu", "Reeves")]
    [Arguments("neo", "Thomas", "Anderson")]
    [Arguments("mr.wick", "John", "Wick")]
    public async Task NestedObject_WithValidNestedAttribute_ShouldPassValidation(string username, string firstName, string lastName)
    {
        // Arrange
        var user = new User
        {
            Username = username,
            UserInfo = new UserInfo
            {
                FirstName = firstName,
                LastName = lastName
            }
        };

        // Act
        bool isValid = user.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    [Arguments("", "John", "Wick")]
    [Arguments("mr.wick", "", "Wick")]
    [Arguments("mr.wick", "John", "")]
    [Arguments("mr.wick", "", "")]
    [Arguments("", "", "")]
    public async Task NestedObject_WithInvalidNestedAttribute_ShouldFailValidation(string username, string firstName, string lastName)
    {
        // Arrange
        var user = new User
        {
            Username = username,
            UserInfo = new UserInfo
            {
                FirstName = firstName,
                LastName = lastName
            }
        };

        // Act
        bool isValid = user.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }
}
