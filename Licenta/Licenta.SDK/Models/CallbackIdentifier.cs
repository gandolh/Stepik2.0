using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.SDK.Models
{
    public class CallbackIdentifier : IEquatable<CallbackIdentifier?>
    {
        public string TopicName { get; set; }
        public string OperationId { get; set; }

        public CallbackIdentifier(string topicName, string opId)
        {
            TopicName = topicName;
            OperationId = opId;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CallbackIdentifier);
        }

        public bool Equals(CallbackIdentifier? other)
        {
            return other is not null &&
                   TopicName == other.TopicName &&
                   OperationId == other.OperationId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TopicName, OperationId);
        }

        public static bool operator ==(CallbackIdentifier? left, CallbackIdentifier? right)
        {
            return EqualityComparer<CallbackIdentifier>.Default.Equals(left, right);
        }

        public static bool operator !=(CallbackIdentifier? left, CallbackIdentifier? right)
        {
            return !(left == right);
        }
    }
}
