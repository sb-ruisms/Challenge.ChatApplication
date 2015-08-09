using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using EA.Challange.ChatClient.Contracts.IService;
using EA.Challange.ChatClient.Models.Models;
using NLog;
using ILogger = EA.Challange.ChatClient.Contracts.IService.ILogger;

namespace EA.Challange.ChatClient.Service.Service
{
    public class Messaging : IMessaging
    {
        private readonly ILogger _logger;
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        public Messaging(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets message from the api
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        public List<string> GetMessage(string address, string port, string fromUserId, string toUserId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", address, port));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync(string.Format("/api/Messages/GetMessage/fromId/{0}/toId/{1}", fromUserId, toUserId)).Result;
                    var messages = response.Content.ReadAsAsync<List<string>>().Result;
                    return messages;
                }
            }
            catch (Exception ex)
            {
                _logger.NLog(Logger, Enums.NLogType.Error, ex.Message);
                _logger.NLog(Logger, Enums.NLogType.Stacktrace, ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Sends message to server
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="message"></param>
        public string SendMessage(string address, string port, Message message)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}:{1}", address, port));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync("/api/Messages/SendMessage", message).Result;
                    if (!response.IsSuccessStatusCode)
                        throw new Exception();
                    return response.Content.ReadAsStringAsync().Result;
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
