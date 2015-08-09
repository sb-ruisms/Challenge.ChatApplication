using System;
using System.Collections.Generic;
using System.Linq;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;
using NLog;
using ILogger = EA.Challenge.ChatAPI.Contracts.ILogger;

namespace EA.Challenge.ChatAPI.Service
{
    public class UserConnection:IUserConnection
    {
        private readonly ILogger _logger;
        public static List<User> ConnectedUsers = new List<User>(); 
        static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        public UserConnection(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Add user to connectedUserList
        /// </summary>
        /// <param name="user"></param>
        public void ConnectUser(User user)
        {
            try
            {
                ConnectedUsers.Add(user);
                _logger.WriteConnectionLog(Enums.ConnectionMode.Connect, user.UserName);
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                _logger.LogToConsole(Enums.NLogType.Error, string.Format("Error occurred while trying to connect user: {0}", user.UserName)); 
            }
        }

        /// <summary>
        /// Method to disconnect user
        /// </summary>
        /// <param name="user"></param>
        public void DisconnectUser(string userId)
        {
            string userName = string.Empty;
            try
            {
                var user = ConnectedUsers.FirstOrDefault(usr => usr.UserId == userId);
                if (user == null) return;
                userName = user.UserName;
                ConnectedUsers.Remove(user);

                var messages =
                    Messaging.MessageList.Where(
                        e => e.MessageFrom.UserId == user.UserId || e.MessageTo.UserId == user.UserId);
                messages.ToList().ForEach(item =>
                {
                    Messaging.MessageList.Remove(item);
                });

                _logger.WriteConnectionLog(Enums.ConnectionMode.Disconnect, userName);
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                _logger.LogToConsole(Enums.NLogType.Error, string.Format("Error occurred while trying to disconnect user: {0}", userName));
            }
        }

        /// <summary>
        /// Gets all the users except userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers(string userId)
        {
            return ConnectedUsers.Where(user=>user.UserId!=userId);
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            return ConnectedUsers;
        }

        /// <summary>
        /// Get user heartbeat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsUserAlive(string id)
        {
            return ConnectedUsers.Any(e => e.UserId == id);
        }
    }
}
