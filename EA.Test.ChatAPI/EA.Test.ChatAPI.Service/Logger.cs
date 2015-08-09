using System;
using System.IO;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;

namespace EA.Challenge.ChatAPI.Service
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
                    logger.Error(string.Format("Error Message: {0}",message));
                    break;
                case Enums.NLogType.Info:
                    logger.Info(message);
                    break;
                case Enums.NLogType.Warn:
                    logger.Warn( message);
                    break;
                case Enums.NLogType.Stacktrace:
                    logger.Error(string.Format("Error Stacktrace: {0}", message));
                    break;
                default:
                    logger.Info(message);
                    break;
            }
        }

        /// <summary>
        /// Writes Messages to file
        /// </summary>
        /// <param name="message"></param>
        public void WriteMessageLog(Message message)
        {
            if (!Directory.Exists("ChatLogs"))
            {
                Directory.CreateDirectory("ChatLogs");
            }
            var filePath = string.Format("ChatLogs\\Chats_On_{0}.txt",
                    DateTime.Now.Date.ToString("MM-dd-yyyy"));

            using (var file = new StreamWriter(filePath, true))
            {
                file.WriteLine(string.Format("[{0}]: From: [{1}], To: [{2}], Message: [{3}]"
                    , DateTime.Now.ToString(@"M/d/yyyy hh:mm:ss tt")
                    , message.MessageFrom.UserName,message.MessageTo.UserName,message.MessageText));
            }
        }

        /// <summary>
        /// Writes to server console
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="message"></param>
        public void LogToConsole(Enums.NLogType mode, string message)
        {
            switch (mode)
            {
                case Enums.NLogType.Error:
                    Console.WriteLine(string.Format("Error: {0}", message));
                    break;
                case Enums.NLogType.Info:
                    Console.WriteLine(string.Format("Info: {0}", message));
                    break;
                case Enums.NLogType.Warn:
                    Console.WriteLine(string.Format("Warning: {0}", message));
                    break;
                case Enums.NLogType.Stacktrace:
                    Console.WriteLine(string.Format("Stacktrace: {0}", message));
                    break;
                default:
                    Console.WriteLine(message);
                    break;
            }
        }

        /// <summary>
        /// Writes connectionLog to file
        /// </summary>
        /// <param name="connectionUser"></param>
        public void WriteConnectionLog(Enums.ConnectionMode mode, string connectionUser)
        {
            if (!Directory.Exists("ConnectionLogs"))
            {
                Directory.CreateDirectory("ConnectionLogs");
            }

            var filePath = string.Format("ConnectionLogs\\Connections_On_{0}.txt",
                    DateTime.Now.Date.ToString("MM-dd-yyyy"));

            using (var file = new StreamWriter(filePath, true))
            {
                switch (mode)
                {
                    case Enums.ConnectionMode.Connect:
                        file.WriteLine(string.Format("[{0}]: User: [{1}] just connected", DateTime.Now.ToString(@"M/d/yyyy hh:mm:ss tt"), connectionUser));
                        break;
                    case Enums.ConnectionMode.Disconnect:
                        file.WriteLine(string.Format("[{0}]: User: [{1}] just disconnected", DateTime.Now.ToString(@"M/d/yyyy hh:mm:ss tt"), connectionUser));
                        break;
                }
            }
        }
    }
}
