using Confluent.Kafka;
using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Services
{
    public interface IKafkaObserver
    {
        Task AddNotifier(string topicName, string opId, Func<KafkaDto, Task> callback);
        void Dispose();
        Task NotifyAsync(ConsumeResult<string, string> consumeResult);
        void RemoveNotifier(string topicName, string opId);
    }
}