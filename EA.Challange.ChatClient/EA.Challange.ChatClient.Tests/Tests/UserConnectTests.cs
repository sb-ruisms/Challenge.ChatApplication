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
    public class UserConnectTests
    {
        private IUserConnect _u;

        public UserConnectTests()
        {
            Initialize();
        }

        public void Initialize()
        {
            
            var logger = new Mock<ILogger>();
            _u = new UserConnect(logger.Object);
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

        public List<User> GetMockUserList()
        {
            return new List<User>
            {
                new User
                {
                    UserId   = "xx", 
                    UserName = "Saikat"
                },
                new User
                {
                    UserId="yy",
                    UserName="Neil"
                }
            };
        }

        [Fact]
        public void GetAllConnectedUsers_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _u.GetAllConnectedUsers("localhost", "9010", "xx"));
            Assert.Null(exception);
        }

        [Fact]
        public void GetMessage_CorrectType_Test()
        {
            Assert.IsType<List<User>>(_u.GetAllConnectedUsers("localhost", "9010", "xx"));
        }

        [Fact]
        public void Connect_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _u.ConnectUser("localhost", "9010", GetMockUserList()[0]));
            Assert.Null(exception);
        }

        [Fact]
        public void Connect_CorrectType_Test()
        {
            Assert.IsType<string>(_u.ConnectUser("localhost", "9010", GetMockUserList()[0]));
        }

        [Fact]
        public void Disconnect_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _u.DisconnectUser("localhost", "9010", GetMockUserList()[0]));
            Assert.Null(exception);
        }

        [Fact]
        public void Disconnect_CorrectType_Test()
        {
            Assert.IsType<string>(_u.DisconnectUser("localhost", "9010", GetMockUserList()[0]));
        }

        [Fact]
        public void GetUserHeartBeat_DoesNotThrowException_Test()
        {
            var exception = Record.Exception(() => _u.GetUserHeartBeat("localhost", "9010", "xx"));
            Assert.Null(exception);
        }

        [Fact]
        public void GetUserHeartBeat_CorrectType_Test()
        {
            Assert.IsType<string>(_u.GetUserHeartBeat("localhost", "9010", "xy"));
        }
    }
}
