using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;
using Moq;
using Xunit;

namespace EA.Challenge.ChatAPI.Tests.Tests
{
    public class LoggerTests
    {
        private ILogger _logger = new Mock<ILogger>().Object;

        [Fact]
        public void NLog_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _logger.LogToConsole(Enums.NLogType.Error, ""));
            Assert.Null(exception);
        }
    }

}
