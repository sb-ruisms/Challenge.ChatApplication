using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Controllers;
using EA.Challenge.ChatAPI.Models;
using Moq;
using Xunit;

namespace EA.Challenge.ChatAPI.Tests.Tests
{
    public class ControllerTests
    {
        private MessagesController _msgController;
        private UserController _usrController;

        public ControllerTests()
        {
            Initialize();
        }
        public void Initialize()
        {
            List<string> strList = new List<string>();
            strList.Add("message");
            strList.Add("message2");

            var userList = new List<User>
            {
                new User
                {
                    UserId="xx",
                    UserName = "Saikat"
                },
                new User
                {
                    UserId = "xy",
                    UserName = "Neil"
                }
            };

            var mock = new Mock<IMessaging>();
            mock.Setup(fake => fake.GetMessage("x", "y")).Returns(strList);
            mock.Setup(fake => fake.AddToMessageList(GetMockMessage())).Returns(false);
             _msgController = new MessagesController(mock.Object);

            var mockIUser = new Mock<IUserConnection>();
            mockIUser.Setup(fake => fake.IsUserAlive("xx")).Returns(true);
            mockIUser.Setup(fake => fake.GetAllUsers()).Returns(userList);
            mockIUser.Setup(fake => fake.GetAllUsers("xx")).Returns(userList.Where(e=>e.UserId!="xx"));
            _usrController = new UserController(mockIUser.Object);
        }

        public Message GetMockMessage()
        {
            return new Message()
            {
                MessageFrom = new User { UserId = "xx", UserName = "Saikat" },
                MessageTo = new User { UserId = "xy", UserName = "Neil" },
                MessageText = "message",
                MessageId = "BBB45T",
                MessageTimeStamp = DateTime.Now
            };
        }

        [Fact]
        public void MessageController_GetMessage_Test()
        {
            _msgController.Request = new HttpRequestMessage();
            _msgController.Configuration = new HttpConfiguration();
            var response = _msgController.Get("x", "y");
            Assert.Equal("message", response[0]);
        }

        [Fact]
        public void MessageController_PostSendMessage_Test()
        {
            _msgController.Request = new HttpRequestMessage();
            _msgController.Configuration = new HttpConfiguration();
            var response = _msgController.PostSendMessage(GetMockMessage());

            Assert.Equal("False", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public void UserController_IsAlive_Test()
        {
            _msgController.Request = new HttpRequestMessage();
            _msgController.Configuration = new HttpConfiguration();
            var response = _usrController.GetUserHeartBeat("xx");

            Assert.Equal(true, response);
        }

        [Fact]
        public void UserController_GetAllUsers_Test()
        {
            _msgController.Request = new HttpRequestMessage();
            _msgController.Configuration = new HttpConfiguration();
            var response = _usrController.GetAllConnectedUsers();

            Assert.Equal(2, response.Count());
        }

        [Fact]
        public void UserController_GetAllUsersById_Test()
        {
            _msgController.Request = new HttpRequestMessage();
            _msgController.Configuration = new HttpConfiguration();
            var response = _usrController.GetAllUsersById("xx");

            Assert.Equal("Neil", response.ToList()[0].UserName);
        }
        
    }
}
