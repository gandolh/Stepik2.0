using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models
{
    public class CallbackIdentifier
    {
        public string TopicName { get; set; }
        public string OperationId { get; set; }

        public CallbackIdentifier(string topicName, string opId)
        {
            TopicName = topicName;
            OperationId = opId;
        }
    }
}
