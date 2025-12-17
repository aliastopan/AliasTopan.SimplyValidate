using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public sealed class NotEmptyGuidAttributeTests
{
    [Test]
    public async Task Object_WithValidNotEmptyGuidAttribute_ShouldPassValidation()
    {
        // Arrange
        var employee = new Employee
        {
            EmployeeId = new ValueObjectId()
        };

        // Act
        bool isValid = employee.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Object_WithInvalidNotEmptyGuidAttribute_ShouldFailValidation()
    {
        // Arrange
        var employee = new Employee
        {
            EmployeeId = new ValueObjectId(Guid.Empty)
        };

        // Act
        bool isValid = employee.Validate(out var _);

        // Assert
        await Assert.That(isValid).IsFalse();
    }

}

