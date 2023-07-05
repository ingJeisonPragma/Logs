using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace Logs.DataAccess.Interface.Entities
{
    [DynamoDBTable("Logs")]
    public class LogEntity
    {
        //[DynamoDBHashKey("Id")]
        public Guid Pk { get; set; } = default!;
        public string App { get; set; } = default!;
        public string User { get; set; } = default!;
        public DateTime DateRegister { get; set; } = default!;
        public string IPAddress { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string Event { get; set; } = default!;
        public int Status { get; set; } = default!;
        public string Error { get; set; } = default!;
    }
}
