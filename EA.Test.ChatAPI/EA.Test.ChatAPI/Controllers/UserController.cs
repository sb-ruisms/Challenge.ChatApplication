using System.Collections.Generic;
using System.Web.Http;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;

namespace EA.Challenge.ChatAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserConnection _userConnection;
        
        public UserController(IUserConnection userConnection)
        {
            _userConnection = userConnection;
        }

        [ActionName("Connect")]
        public void PostConnect([FromBody] User user)
        {
            _userConnection.ConnectUser(user);
        }

        [ActionName("Disconnect")]
        public void PostDisconnect([FromBody] User user)
        {
            _userConnection.DisconnectUser(user.UserId);
        }

        [ActionName("GetUsers")]
        public IEnumerable<User> GetAllUsersById(string id)
        {
            return _userConnection.GetAllUsers(id);
        }

        [ActionName("GetAllUsers")]
        public IEnumerable<User> GetAllConnectedUsers()
        {
            return _userConnection.GetAllUsers();
        }

        [ActionName("GetUserHeartBeat")]
        public bool GetUserHeartBeat(string id)
        {
            return _userConnection.IsUserAlive(id);
        }
    }
}
