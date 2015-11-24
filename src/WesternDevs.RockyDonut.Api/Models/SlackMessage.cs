using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WesternDevs.RockyDonut.Api.Models
{
    public class SlackMessage : TableEntity
    {
        public string ChannelId { get; private set; }
        public string ChannelName { get; private set; }
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Text { get; private set; }
        public DateTime Timestamp { get; private set; }

        public SlackMessage(string channelId, string channelName, string userId, string userName, string text, DateTime timestamp)
        {
            ChannelId = channelId;
            ChannelName = channelName;
            UserId = userId;
            UserName = userName;
            Text = text;
            Timestamp = timestamp;
        }
    }
}