using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Models;

namespace EA.Challenge.ChatAPI.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMessaging _messaging;
        public MessagesController(IMessaging messaging)
        {
            _messaging = messaging;
        }

        [ActionName("SendMessage")]
        public HttpResponseMessage PostSendMessage([FromBody] Message message)
        {
            var isToUserAlive = _messaging.AddToMessageList(message);
            return new HttpResponseMessage {Content = new StringContent(isToUserAlive.ToString())};
        }

        [ActionName("GetMessage")]
        public List<string> Get(string fromId, string toId)
        {
            return _messaging.GetMessage(fromId, toId);
        }
    }
}
