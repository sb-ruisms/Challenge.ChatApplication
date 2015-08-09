using System;
using System.Collections.Generic;
using System.Linq;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;
using NLog;
using ILogger = EA.Challenge.ChatAPI.Contracts.ILogger;

namespace EA.Challenge.ChatAPI.Service
{
    public class Messaging : IMessaging
    {
        private readonly ILogger _logger;
        static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        public static List<Message> MessageList = new List<Message>();

        public Messaging(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Adds to message list
        /// </summary>
        /// <param name="message"></param>
        public bool AddToMessageList(Message message)
        {
            try
            {
                if (UserConnection.ConnectedUsers.Any(e => e.UserId == message.MessageTo.UserId))
                {
                    MessageList.Add(message);
                    _logger.WriteMessageLog(message);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                _logger.LogToConsole(Enums.NLogType.Error, "Error occurred while trying to add new message");
                throw;
            }
        }

        /// <summary>
        /// Get message for fromUser-toUser combination
        /// </summary>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        public List<string> GetMessage(string fromUserId, string toUserId)
        {
            try
            {
                var messages = MessageList.Where(msg => msg.MessageTo.UserId == toUserId && msg.MessageFrom.UserId == fromUserId);
                var finalResult = new List<string>();
                messages.ToList().ForEach(item =>
                {
                    finalResult.Add(item.MessageText);
                    MessageList.Remove(item);
                });
                return finalResult;
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                _logger.LogToConsole(Enums.NLogType.Error, "Error occurred while trying to add new message");
                throw;
            }
        }
    }
}
