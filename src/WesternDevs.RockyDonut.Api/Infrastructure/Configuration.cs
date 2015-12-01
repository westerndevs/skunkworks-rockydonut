using System;
using System.Configuration;

namespace WesternDevs.RockyDonut.Api.Infrastructure
{
    public class Configuration:IConfiguration
    {
        public string RawSlackMessageTableName => ConfigurationManager.AppSettings["rawMessageTableName"];
        public string AzureStorageConnectionString => ConfigurationManager.AppSettings["AzureStorageConnectionString"];
        public string[] SlackWebhookToken => ConfigurationManager.AppSettings["SlackWebhookToken"].Split(',');
        public string SlackTeamDomain => ConfigurationManager.AppSettings["SlackTeamDomain"];
        public string SlackTeamId => ConfigurationManager.AppSettings["SlackTeamId"];
        public string[] SlackServiceId => ConfigurationManager.AppSettings["SlackServiceId"].Split(',');
    }
}