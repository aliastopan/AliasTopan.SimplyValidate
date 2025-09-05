using AliasTopan.SimplyValidate.UnitTests.Models;

namespace AliasTopan.SimplyValidate.UnitTests;

public class ValidateWithLogTest
{
    [Test]
    [Arguments("user.name", "")]
    [Arguments("", "p@ss.word012")]
    [Arguments("", "")]
    public async Task Object_WithInvalidDataAnnotation_ShouldOutJsonErrorLog(string username, string password)
    {
        // Arrange
        var request = new LoginRequest
        {
            Username = username,
            Password = password
        };

        // Act
        bool _ = request.ValidateWithLog(out string jsonErrorLog, writeIndented: true);
        bool isJsonString = !string.IsNullOrEmpty(jsonErrorLog);

        // Assert
        await Assert.That(isJsonString).IsTrue();

        Console.WriteLine(jsonErrorLog);
    }

    [Test]
    [Arguments("user.name", "p@ss.word012", true)]
    [Arguments("user.name", "p@ss.word012", false)]
    public async Task Object_WithValidDataAnnotation_ShouldOutEmptyJsonErrorLog(string username, string password, bool writeIndented)
    {
        // Arrange
        var emptyJsonErrorLog = writeIndented
            ? "{\n  \"ValidationErrors\": []\n}"
            : "{\"ValidationErrors\":[]}";

        var request = new LoginRequest
        {
            Username = username,
            Password = password
        };

        // Act
        bool _ = request.ValidateWithLog(out string jsonErrorLog, writeIndented: writeIndented);

        // Assert
        await Assert.That(jsonErrorLog).IsEqualTo(emptyJsonErrorLog);

        Console.WriteLine(jsonErrorLog);
    }
}
