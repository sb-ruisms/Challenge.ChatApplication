using System.Collections.Generic;
using EA.Challenge.ChatAPI.Models;

namespace EA.Challenge.ChatAPI.Contracts
{
    public interface IMessaging
    {
        bool AddToMessageList(Message message);
        List<string> GetMessage(string fromUserId, string toUserId);
    }
}
