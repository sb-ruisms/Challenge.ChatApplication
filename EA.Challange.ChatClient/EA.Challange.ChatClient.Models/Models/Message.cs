using System;

namespace EA.Challange.ChatClient.Models.Models
{
    public class Message
    {
        public string MessageId { get; set; }
        public User MessageFrom { get; set; }
        public User MessageTo { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTimeStamp { get; set; }
    }
}
