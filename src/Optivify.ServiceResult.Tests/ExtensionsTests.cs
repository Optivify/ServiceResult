namespace Optivify.ServiceResult.Tests;

[TestClass]
public class ExtensionsTests
{
    #region ResultStatus

    [DataRow("Message 1 ", "Message 2. ", "Message 3.", "Message 4..")]
    [TestMethod]
    public void VerifyJoinStrings(params string[] messages)
    {
        var joinedStrings = messages.JoinStrings();
        Assert.AreEqual("Message 1. Message 2. Message 3. Message 4..", joinedStrings);
    }
    #endregion
}