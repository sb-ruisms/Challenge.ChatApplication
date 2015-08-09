using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Windows.Forms;
using EA.Challange.ChatClient.Contracts.IService;
using EA.Challange.ChatClient.Models.Models;
using NLog;
using ILogger = EA.Challange.ChatClient.Contracts.IService.ILogger;

namespace EA.Challange.ChatClient.Service.Service
{
    public class UserConnect : IUserConnect
    {
        private readonly ILogger _logger;
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        public UserConnect(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets all the user
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<User> GetAllConnectedUsers(string address, string port, string userId)
        {
            var users = new List<User>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", address, port));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(string.Format("/api/user/GetUsers/{0}", userId)).Result;
                    users = response.Content.ReadAsAsync<List<User>>().Result;
                }
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                throw;
            }
            return users;
        }

        /// <summary>
        /// Connect User
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string ConnectUser(string address, string port, User user)
        {
            var message = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", address, port));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync("/api/User/Connect", user).Result;

                    if (response.IsSuccessStatusCode)
                        message = "You were successfully logged in";
                }
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                throw;
            }
            return message;
        }

        /// <summary>
        /// Disconnect User
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string DisconnectUser(string address, string port, User user)
        {
            var message = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", address, port));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync("/api/User/Disconnect", user).Result;

                    if (response.IsSuccessStatusCode)
                        message = "You were successfully logged out";
                }
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace); 
                throw;
            }
            return message;
        }

        /// <summary>
        /// Gets if user is alive or not
        /// </summary>
        /// <param name="port"></param>
        /// <param name="userId"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool GetUserHeartBeat(string address, string port,string userId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", address, port));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(string.Format("/api/user/GetUserHeartBeat/{0}", userId)).Result;
                    return response.Content.ReadAsAsync<bool>().Result;
                }
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                throw;
            }
        }
    }
}
