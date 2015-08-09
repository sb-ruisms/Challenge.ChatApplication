using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;
using EA.Challenge.ChatAPI.Service;
using Moq;
using Xunit;

namespace EA.Challenge.ChatAPI.Tests.Tests
{
    [ExcludeFromCodeCoverage]
    public class UserConnectionTests
    {
        private UserConnection _u;

        public UserConnectionTests()
        {
            Initialize();
        }

        public void Initialize()
        {
            var logger = new Mock<ILogger>();
            _u = new UserConnection(logger.Object);
        }

        //private readonly IUserConnection _u = new Mock<IUserConnection>().Object;
        [Fact]
        public void ConnectUser_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _u.ConnectUser(new User { UserId = "xx", UserName = "Saikat" }));
            Assert.Null(exception);
        }

        [Fact]
        public void DisconnectUser_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _u.DisconnectUser("xx"));
            Assert.Null(exception);
        }

        [Fact]
        public void GetAllUsersById_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _u.GetAllUsers("xx"));
            Assert.Null(exception);
        }

        [Fact]
        public void GetAllUsers_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _u.GetAllUsers());
            Assert.Null(exception);
        }

        [Fact]
        public void IsAlive_ThrowsNoException_Test()
        {
            var exception = Record.Exception(() => _u.IsUserAlive("xx"));
            Assert.Null(exception);
        }

        //Value correctness
        [Fact]
        public void GetAllUsersById_GetValue_Test()
        {
            UserConnection.ConnectedUsers.Add(new User { UserId = "xx", UserName = "Saikat" });
            UserConnection.ConnectedUsers.Add(new User { UserId = "xy", UserName = "Neil" });

            Assert.Equal("Neil", _u.GetAllUsers("xx").ToList()[0].UserName);
        }

        [Fact]
        public void IsUserAlive_GetValueInvert_Test()
        {
            UserConnection.ConnectedUsers.Clear();
            UserConnection.ConnectedUsers.Add(new User { UserId = "xx", UserName = "Saikat" });
            UserConnection.ConnectedUsers.Add(new User { UserId = "xy", UserName = "Neil" });

            UserConnection.ConnectedUsers.RemoveAll(x => x.UserId.StartsWith("x"));

            Assert.Equal(false, _u.IsUserAlive("xx"));
        }
    }
}
