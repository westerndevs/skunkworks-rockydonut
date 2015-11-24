﻿using System;
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

        // POST api/<controller>
        [HttpPost]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void Post([FromBody] string token, [FromBody] string team_id, [FromBody] string team_domain,
            [FromBody] string service_id, [FromBody] string channel_id,
            [FromBody] string channel_name, [FromBody] double timestamp, [FromBody] string user_id,
            [FromBody] string user_name, [FromBody] string text)
        {
            //filter off messages from unknown sources based on token, team_domain, team_id, service_id

            //push to table storage
            var message = new SlackMessage(channel_id, channel_name, user_id, user_name, text,
                new DateTime(1970, 1, 1).AddSeconds(timestamp));

            var storage = CloudStorageAccount.Parse(_configuration.AzureStorageConnectionString);

            var tableClient = storage.CreateCloudTableClient();
            var table = tableClient.GetTableReference(_configuration.RawSlackMessageTableName);
            table.CreateIfNotExists();
            var insertOperation = TableOperation.Insert(message);
            table.Execute(insertOperation);
        }
    }
}