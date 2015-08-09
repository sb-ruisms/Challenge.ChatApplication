using System.Collections.Generic;
using EA.Challenge.ChatAPI.Models;

namespace EA.Challenge.ChatAPI.Contracts
{
    public interface IUserConnection
    {
        void ConnectUser(User user);
        void DisconnectUser(string userId);
        IEnumerable<User> GetAllUsers(string userId);
        IEnumerable<User> GetAllUsers();
        bool IsUserAlive(string id);
    }
}
