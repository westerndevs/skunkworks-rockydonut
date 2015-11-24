using System.Configuration;

namespace WesternDevs.RockyDonut.Api.Infrastructure
{
    public class Configuration:IConfiguration
    {
        public string RawSlackMessageTableName => "rawSlackMessage";
        public string AzureStorageConnectionString => ConfigurationManager.AppSettings["AzureStorageConnectionString"];
    }
}