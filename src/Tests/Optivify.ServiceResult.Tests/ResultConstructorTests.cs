namespace Optivify.ServiceResult.Tests
{
    [TestClass]
    public class ResultTests
    {
        private class TestClass
        {
        }

        #region ResultStatus

        [DataRow(ResultStatus.Success)]
        [DataRow(ResultStatus.Error)]
        [DataRow(ResultStatus.Invalid)]
        [DataRow(ResultStatus.NotFound)]
        [DataRow(ResultStatus.Unauthorized)]
        [DataRow(ResultStatus.Forbidden)]
        [TestMethod]
        public void VerifyResultStatus_Object(ResultStatus expectedStatus)
        {
            var result = new Result<object>(expectedStatus);

            Assert.AreEqual(expectedStatus, result.Status);
            Assert.IsNull(result.Value);
        }

        [DataRow(ResultStatus.Success)]
        [DataRow(ResultStatus.Error)]
        [DataRow(ResultStatus.Invalid)]
        [DataRow(ResultStatus.NotFound)]
        [DataRow(ResultStatus.Unauthorized)]
        [DataRow(ResultStatus.Forbidden)]
        [TestMethod]
        public void VerifyResultStatus_Class(ResultStatus expectedStatus)
        {
            var result = new Result<TestClass>(expectedStatus);

            Assert.AreEqual(expectedStatus, result.Status);
            Assert.IsNull(result.Value);
        }

        #endregion

        #region Value

        [DataRow("A string value")]
        [TestMethod]
        public void VerifyResultValue_String(string expectedValue)
        {
            var result = new Result<string>(expectedValue);

            Assert.AreEqual(expectedValue, result.Value);
        }

        [DataRow(100)]
        [TestMethod]
        public void VerifyResultValue_Int(int expectedValue)
        {
            var result = new Result<int>(expectedValue);

            Assert.AreEqual(expectedValue, result.Value);
        }

        [DataRow(236)]
        [DataRow("Nice!")]
        [DataRow(null)]
        [TestMethod]
        public void VerifyResultValue_Object(object expectedValue)
        {
            var result = new Result<object>(expectedValue);

            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void VerifyResultValue_Class()
        {
            var expectedValue = new TestClass();
            var result = new Result<TestClass>(expectedValue);

            Assert.AreEqual(expectedValue, result.Value);
        }

        #endregion
    }
}