namespace WesternDevs.RockyDonut.Api.Infrastructure
{
    public interface IConfiguration
    {
        string RawSlackMessageTableName { get; }
        string AzureStorageConnectionString { get; }
        string[] SlackWebhookToken { get;}
        string SlackTeamDomain { get; }
        string SlackTeamId { get; }
        string SlackServiceId { get; }
    }
}