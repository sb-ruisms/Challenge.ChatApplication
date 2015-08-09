using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EA.Challange.ChatClient.Contracts.IService;
using EA.Challange.ChatClient.Models.Models;
using EA.Challange.ChatClient.Service.Service;
using Moq;
using Xunit;

namespace EA.Challange.ChatClient.Tests.Tests
{
    [ExcludeFromCodeCoverage]
    public class MessageServiceTests
    {
        private IMessaging _m;

        public MessageServiceTests()
        {
            Initialize();
        }

        public void Initialize()
        {
            
            var logger = new Mock<ILogger>();
            _m = new Messaging(logger.Object);
        }

        public Message GetMockMessage()
        {
            return new Message()
            {
                MessageFrom = new User { UserId="xx", UserName = "Saikat"},
                MessageTo = new User { UserId = "xy", UserName = "Neil" },
                MessageText = "message",
                MessageId = "BBB45T",
                MessageTimeStamp = DateTime.Now
            };
        }

        [Fact]
        public void GetMessage_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _m.GetMessage("localhost", "9010", "xx", "xy"));
            Assert.Null(exception);
        }

        [Fact]
        public void GetMessage_CorrectType_Test()
        {
            Assert.IsType<List<string>>(_m.GetMessage("localhost", "9010", "xx", "xy"));
        }

        [Fact]
        public void SendMessage_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _m.SendMessage("localhost", "9010", GetMockMessage()));
            Assert.Null(exception);
        }

        [Fact]
        public void SendMessage_CorrectType_Test()
        {
            Assert.IsType<bool>(_m.SendMessage("localhost", "9010", GetMockMessage()));
        }
    }
}
