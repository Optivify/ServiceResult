namespace Optivify.ServiceResult.Tests;

[TestClass]
public class ResultMethodTests
{
    private class TestClass
    {
        public string? Name { get; set; }

        public int Age { get; set; }
    }

    #region Success

    [TestMethod]
    public void VerifySuccessMethod_GivenObject_ReturnCorrectStatusAndValue()
    {
        var obj = new TestClass();
        var result = Result<TestClass>.Success(obj);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(obj, result.Value);
    }

    [TestMethod]
    public void VerifySuccessMethod_GivenValueAndSuccessMessage_ReturnCorrectStatusAndValueAndSuccessMessage()
    {
        const string successMessage = "Done!";
        var obj = new TestClass();
        var result = Result<TestClass>.Success(obj, successMessage);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(obj, result.Value);
        Assert.AreEqual(successMessage, result.SuccessMessage);
    }

    #endregion

    #region Error

    [TestMethod]
    public void VerifyErrorMethod_GivenErrorMessages_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2" };
        var result = Result<TestClass>.Error(errorMessages);

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
                PropertyName = nameof(TestClass.Name),
                ErrorMessage = "Name is required."
            },
            new()
            {
                PropertyName = nameof(TestClass.Age),
                ErrorMessage = "Age must be greater than 13."
            }
        };

        var result = Result<TestClass>.Invalid(validationErrors.ToArray());

        Assert.IsNotNull(result.ValidationErrors);
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
        var result = Result<TestClass>.Unauthorized();

        Assert.AreEqual(ResultStatus.Unauthorized, result.Status);
        Assert.IsNull(result.Value);
    }

    [TestMethod]
    public void VerifyUnauthorizedMethod_GivenErrorMessage_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2", "Error message 3" };
        var result = Result<TestClass>.Unauthorized(errorMessages);

        Assert.AreEqual(ResultStatus.Unauthorized, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region Forbidden

    [TestMethod]
    public void VerifyForbiddenMethod_GivenNothing_ReturnCorrectStatus()
    {
        var result = Result<TestClass>.Forbidden();

        Assert.AreEqual(ResultStatus.Forbidden, result.Status);
        Assert.IsNull(result.Value);
    }

    [TestMethod]
    public void VerifyForbiddenMethod_GivenErrorMessage_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2", "Error message 3" };
        var result = Result<TestClass>.Unauthorized(errorMessages);

        Assert.AreEqual(ResultStatus.Unauthorized, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion

    #region NotFound

    [TestMethod]
    public void VerifyNotFoundMethod_GivenNothing_ReturnCorrectStatus()
    {
        var result = Result<TestClass>.NotFound();

        Assert.AreEqual(ResultStatus.NotFound, result.Status);
        Assert.IsNull(result.Value);
    }

    [TestMethod]
    public void VerifyNotFoundMethod_GivenErrorMessage_ReturnCorrectStatusAndErrorMessages()
    {
        var errorMessages = new[] { "Error message 1", "Error message 2", "Error message 3" };
        var result = Result<TestClass>.NotFound(errorMessages);

        Assert.AreEqual(ResultStatus.NotFound, result.Status);
        Assert.AreEqual(errorMessages, result.ErrorMessages);
        Assert.IsNull(result.Value);
    }

    #endregion
}