
using System.Collections.Generic;
using EA.Challange.ChatClient.Models.Models;

namespace EA.Challange.ChatClient.Contracts.IService
{
    public interface IMessaging
    {
        List<string> GetMessage(string address, string port, string fromUserId, string toUserId);
        string SendMessage(string address, string port, Message message);
    }
}
