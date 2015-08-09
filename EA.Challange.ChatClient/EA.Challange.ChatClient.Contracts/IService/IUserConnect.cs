using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.Challange.ChatClient.Models.Models;

namespace EA.Challange.ChatClient.Contracts.IService
{
    public interface IUserConnect
    {
        List<User> GetAllConnectedUsers(string address, string port, string userId);
        string ConnectUser(string address, string port, User user);
        string DisconnectUser(string address, string port, User user);
        bool GetUserHeartBeat(string address, string port, string userId);
    }
}