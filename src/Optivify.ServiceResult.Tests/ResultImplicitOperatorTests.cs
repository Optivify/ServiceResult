namespace Optivify.ServiceResult.Tests;

[TestClass]
public class ResultImplicitOperatorTests
{
    private class TestClass
    {
    }

    public Result<T?> PerformExample<T>(T? testValue) => testValue;

    public T? GetValueExample<T>(Result<T?> testResult) => testResult;

    [TestMethod]
    public void VerifyImplicitOperator_GivenResult_ReturnCorrectValue_Success()
    {
        var obj = new TestClass();
        var result = Result.Success(obj);
        var castObj = GetValueExample(result);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(obj, castObj);
    }

    [TestMethod]
    public void VerifyImplicitOperator_GivenResult_ReturnCorrectValue_Invalid()
    {
        var result = Result.Invalid(new ValidationError
        {
            PropertyName = "property",
            ErrorMessage = "error",
            ErrorCode = "code",
            Severity = ValidationSeverity.Info
        });

        Assert.IsNotNull(result.ValidationErrors);
        Assert.AreEqual(ResultStatus.Invalid, result.Status, "ResultStatus");
        Assert.AreEqual("property", result.ValidationErrors[0].PropertyName);
        Assert.AreEqual("error", result.ValidationErrors[0].ErrorMessage);
        Assert.AreEqual("code", result.ValidationErrors[0].ErrorCode);
        Assert.AreEqual(ValidationSeverity.Info, result.ValidationErrors[0].Severity);
    }

    [TestMethod]
    public void VerifyImplicitOperator_GivenValue_ReturnCorrectResult()
    {
        var obj = new TestClass();
        var result = PerformExample(obj);

        Assert.AreEqual(ResultStatus.Success, result.Status);
        Assert.AreEqual(obj, result.Value);
    }
}