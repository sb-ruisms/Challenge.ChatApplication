using EA.Challenge.ChatAPI.Models;
using NLog;

namespace EA.Challenge.ChatAPI.Contracts
{
    public interface ILogger
    {
        void NLog(Logger logger, Enums.NLogType mode, string message);
        void WriteMessageLog(Message message);
        void WriteConnectionLog(Enums.ConnectionMode mode, string connectionUser);
        void LogToConsole(Enums.NLogType mode, string message);
    }
}
