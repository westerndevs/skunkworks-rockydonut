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
        public DateTime MessageTimestamp { get; private set; }
        public Guid Id { get; private set; }
        public double Sentiment { get; set; }

        public SlackMessage(string channelId, string channelName, string userId, string userName, string text, DateTime messageTimestamp)
        {
            ChannelId = channelId;
            ChannelName = channelName;
            UserId = userId;
            UserName = userName;
            Text = text;
            MessageTimestamp = messageTimestamp;
            Id = Guid.NewGuid();
            PartitionKey = channelId;
            RowKey = Id.ToString();
        }
        
    }
}