using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models.Dtos
{
    public class KafkaDto
    {
        public required string UserId { get; set; }
        public required string OperationId { get; set; }
        public required string Body { get; set; }

        public KafkaDto(string userId, string operationId, string body)
        {
            UserId = userId;
            OperationId = operationId;
            Body = body;
        }
    }
}
