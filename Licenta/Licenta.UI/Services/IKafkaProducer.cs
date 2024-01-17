
namespace Licenta.UI.Services
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string topicName, string key, object value);
    }
}