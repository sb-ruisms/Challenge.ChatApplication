using System;
using EA.Challange.ChatClient.Contracts.IService;
using EA.Challange.ChatClient.Models.Models;

namespace EA.Challange.ChatClient.Service.Service
{
    public class Logger : ILogger
    {
        /// <summary>
        /// Writes to NLog file for basic application wide logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mode"></param>
        /// <param name="message"></param>
        public void NLog(NLog.Logger logger, Enums.NLogType mode, string message)
        {
            switch (mode)
            {
                case Enums.NLogType.Error:
                    logger.Error(string.Format("Error Message: {0}", message));
                    break;
                case Enums.NLogType.Info:
                    logger.Info(message);
                    break;
                case Enums.NLogType.Warn:
                    logger.Warn(message);
                    break;
                case Enums.NLogType.Stacktrace:
                    logger.Error(string.Format("Error Stacktrace: {0}", message));
                    break;
                default:
                    logger.Info(message);
                    break;
            }
        }
    }
}
