using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WesternDevs.RockyDonut.Api.Models
{
    public class SlackMessage : TableEntity
    {
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime MessageTimestamp { get; set; }
        public Guid Id { get; set; }
        public SlackMessage() {}
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