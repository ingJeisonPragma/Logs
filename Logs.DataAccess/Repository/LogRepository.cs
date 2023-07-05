using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Logs.DataAccess.Interface.Entities;
using Logs.DataAccess.Interface.IRepository;
using Logs.Domain.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logs.DataAccess.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly IAmazonDynamoDB _dynamoDB;
        private readonly IDynamoDBContext dynamoDBContext;

        public LogRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext dynamoDBContext)
        {
            this._dynamoDB = dynamoDB;
            this.dynamoDBContext = dynamoDBContext;
        }

        public async Task<bool> CreateLogItem(LogEntity entity)
        {
            var logsAsJson = JsonSerializer.Serialize(entity);
            var itemAsLog = Document.FromJson(logsAsJson);
            var itemAsAttributtes = itemAsLog.ToAttributeMap();

            var createItem = new PutItemRequest
            {
                TableName = "Logs",
                Item = itemAsAttributtes
            };

            var response = await _dynamoDB.PutItemAsync(createItem);

            return response.HttpStatusCode == HttpStatusCode.OK;

        }

        public async Task<bool> CreateLogDBContext(LogEntity entity)
        {
            await dynamoDBContext.SaveAsync(entity);
            return true;
        }

        public async Task<List<LogEntity>> GetAllLog()
        {
            var logResult = await dynamoDBContext.ScanAsync<LogEntity>(default).GetRemainingAsync();
            return logResult;
        }

        public async Task<List<LogEntity>> GetByApp(string App)
        {
            var entity = await dynamoDBContext.ScanAsync<LogEntity>(default).GetRemainingAsync();
            var logEntities = entity.Where(c => c.App.Equals(App)).ToList();
            return logEntities;
        }

        public async Task<LogEntity> GetById(Guid Id)
        {
            var entity = await dynamoDBContext.LoadAsync<LogEntity>(Id);
            return entity;
        }
    }
}
