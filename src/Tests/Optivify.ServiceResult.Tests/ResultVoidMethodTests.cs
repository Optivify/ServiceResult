namespace Optivify.ServiceResult.Tests;

[TestClass]
public class ResultVoidMethodTests
{
    private class TestClass
    {
    }

    #region Success

    [TestMethod]
    public void VerifySuccessMethod_GivenObject_ReturnCorrectValue()
    {
        var obj = new TestClass();
        var result = Result.Success(obj);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(obj, result.Value);
    }

    [TestMethod]
    public void VerifySuccessMethod_GivenValueAndSuccessMessage_ReturnCorrectValueAndMessage()
    {
        var obj = new TestClass();
        var successMessage = "Done!";
        var result = Result.Success(obj, successMessage);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(obj, result.Value);
        Assert.AreEqual(successMessage, result.SuccessMessage);
    }

    [TestMethod]
    public void VerifySuccessWithMessageMethod_GivenSuccessMessage_ReturnCorrectMessage()
    {
        var successMessage = "Done!";
        var result = Result.SuccessWithMessage(successMessage);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(successMessage, result.SuccessMessage);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region Error

    [TestMethod]
    public void VerifyErrorMethod_GivenErrorMessages_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2" };
        var result = Result.Error(errorMessages);

        Assert.AreEqual(ResultStatus.Error, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region Invalid

    [TestMethod]
    public void VerifyInvalidMethod_GivenValidationErrors_ReturnCorrectStatusAndValidationErrors()
    {
        var validationErrors = new List<ValidationError>
        {
            new()
            {
                PropertyName = "Name",
                ErrorMessage = "Name is required."
            },
            new()
            {
                PropertyName = "Age",
                ErrorMessage = "Age must be greater than 13."
            }
        };

        var result = Result.Invalid(validationErrors.ToArray());

        Assert.AreEqual(ResultStatus.Invalid, result.Status);
        Assert.AreEqual(validationErrors[0], result.ValidationErrors[0]);
        Assert.AreEqual(validationErrors[1], result.ValidationErrors[1]);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region Unauthorized

    [TestMethod]
    public void VerifyUnauthorizedMethod_GivenNothing_ReturnCorrectStatus()
    {
        var result = Result.Unauthorized();

        Assert.AreEqual(ResultStatus.Unauthorized, result.Status);
        Assert.IsNull(result.Value);
    }

    [TestMethod]
    public void VerifyUnauthorizedMethod_GivenErrorMessage_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2", "Error message 3" };
        var result = Result.Unauthorized(errorMessages);

        Assert.AreEqual(ResultStatus.Unauthorized, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region Forbidden

    [TestMethod]
    public void VerifyForbiddenMethod_GivenNothing_ReturnCorrectStatus()
    {
        var result = Result.Forbidden();

        Assert.AreEqual(ResultStatus.Forbidden, result.Status);
        Assert.IsNull(result.Value);
    }

    [TestMethod]
    public void VerifyForbiddenMethod_GivenErrorMessage_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2", "Error message 3" };
        var result = Result.Unauthorized(errorMessages);

        Assert.AreEqual(ResultStatus.Unauthorized, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region NotFound

    [TestMethod]
    public void VerifyNotFoundMethod_GivenNothing_ReturnCorrectStatus()
    {
        var result = Result.NotFound();

        Assert.AreEqual(ResultStatus.NotFound, result.Status);
        Assert.IsNull(result.Value);
    }

    [TestMethod]
    public void VerifyNotFoundMethod_GivenErrorMessage_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2", "Error message 3" };
        var result = Result.NotFound(errorMessages);

        Assert.AreEqual(ResultStatus.NotFound, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion
}