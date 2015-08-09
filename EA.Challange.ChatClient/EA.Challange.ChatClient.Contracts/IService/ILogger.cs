using EA.Challange.ChatClient.Models.Models;
namespace EA.Challange.ChatClient.Contracts.IService
{
    public interface ILogger
    {
        void NLog(NLog.Logger logger, Enums.NLogType mode, string message);
    }
}
