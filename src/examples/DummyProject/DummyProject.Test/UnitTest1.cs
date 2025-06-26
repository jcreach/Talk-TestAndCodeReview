using DummyProject.Common.Core;
using DummyProject.Test.MockModel;

namespace DummyProject.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ResultFailure_Should_ReturnAnErrorWithStatusAndDescription()
        {
            // Arrange
            string errorCode = "TestError.Mock";
            string errorDescription = "This is an error !";
            Error testError = new Error(errorCode, errorDescription);

            // Act
            var result = Result<MockObject>.Failure(testError);

            // Assert
            Assert.True(result.IsFailure);
            Assert.True(result.Error.Code == errorCode);
            Assert.True(result.Error.Description == errorDescription);
        }

    }
}