using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;
using EA.Challenge.ChatAPI.Service;
using Moq;
using Xunit;

namespace EA.Challenge.ChatAPI.Tests.Tests
{
    [ExcludeFromCodeCoverage]
    public class MessagingTests
    {
        private IMessaging _m;

        public MessagingTests()
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

        ///Exception tests
        [Fact]
        public void AddToMessageList_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _m.AddToMessageList(GetMockMessage()));
            Assert.Null(exception);
        }

        [Fact]
        public void GetMessage_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _m.GetMessage("x", "y"));
            Assert.Null(exception);
        }

        //ValueType Tests
        [Fact]
        public void AddToMessageList_ReturnsCorrectValueType_Test()
        {
            Assert.IsType<bool>(_m.AddToMessageList(GetMockMessage()));
        }

        [Fact]
        public void GetMessage_ReturnsCorrectValueType_Test()
        {
            Assert.IsType<List<string>>(_m.GetMessage("x", "y"));
        }

        //Value Tests
        [Fact]
        public void AddToMessageList_ReturnsCorrectValue_Test()
        {
            UserConnection.ConnectedUsers.Add(new User { UserId = "xy", UserName = "Neil" });
            Assert.Equal(true, _m.AddToMessageList(GetMockMessage()));
        }

        [Fact]
        public void GetMessage_ReturnsCorrectValue_Test()
        {
            Messaging.MessageList.Add(GetMockMessage());
            Assert.Equal("message", _m.GetMessage("xx", "xy")[0]);
        }
    }
}
