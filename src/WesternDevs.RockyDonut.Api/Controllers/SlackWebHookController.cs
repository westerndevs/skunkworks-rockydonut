using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using WesternDevs.RockyDonut.Api.Infrastructure;
using WesternDevs.RockyDonut.Api.Models;

namespace WesternDevs.RockyDonut.Api.Controllers
{
    public class SlackWebHookController : ApiController
    {
        private readonly IConfiguration _configuration;

        public SlackWebHookController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpPost]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void Post([FromBody] RawMessage rawMessage)
        {
            if (NotValidMessage(rawMessage)) return;

            //push to table storage
            var message = new SlackMessage(rawMessage.channel_id, rawMessage.channel_name, rawMessage.user_id, rawMessage.user_name, rawMessage.text,
                new DateTime(1970, 1, 1).AddSeconds(Convert.ToDouble(rawMessage.timestamp)));

            try
            {
                var storage = CloudStorageAccount.Parse(_configuration.AzureStorageConnectionString);
                var tableClient = storage.CreateCloudTableClient();
                var table = tableClient.GetTableReference(_configuration.RawSlackMessageTableName);
                table.CreateIfNotExists();
                var insertOperation = TableOperation.Insert(message);
                table.Execute(insertOperation);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        private bool NotValidMessage(RawMessage rawMessage)
        {
            if (string.Compare(_configuration.SlackWebhookToken, rawMessage.token, StringComparison.CurrentCultureIgnoreCase) != 0) return true;

            if (string.Compare(_configuration.SlackTeamDomain, rawMessage.team_domain, StringComparison.CurrentCultureIgnoreCase) != 0) return true;

            if (string.Compare(_configuration.SlackTeamId, rawMessage.team_id, StringComparison.CurrentCultureIgnoreCase) != 0) return true;

            if (string.Compare(_configuration.SlackServiceId, rawMessage.service_id, StringComparison.CurrentCultureIgnoreCase) != 0) return true;

            return false;
        }
    }
}