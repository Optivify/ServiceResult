namespace Optivify.ServiceResult.Tests
{
    [TestClass]
    public class ResultImplicitOperatorTests
    {
        private class TestClass
        {
        }

        public Result<T> PerformExample<T>(T testValue) => testValue;

        public T? GetValueExample<T>(Result<T> testResult) => testResult;

        [TestMethod]
        public void VerifyImplicitOperator_GivenResult_ReturnCorrectValue()
        {
            var obj = new TestClass();
            var result =  Result.Success(obj);
            var castedObj = this.GetValueExample(result);

            Assert.AreEqual(ResultStatus.Success, (ResultStatus)result.Status);
            Assert.AreEqual(obj, castedObj);
        }

        [TestMethod]
        public void VerifyImplicitOperator_GivenValue_ReturnCorrectResult()
        {
            var obj = new TestClass();
            var result = this.PerformExample(obj);

            Assert.AreEqual(ResultStatus.Success, result.Status);
            Assert.AreEqual(obj, result.Value);
        }
    }
}