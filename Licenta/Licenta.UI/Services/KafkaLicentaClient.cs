using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Services
{
    public class KafkaLicentaClient
    {
        private readonly IKafkaObserver _kafkaObserver;
        private readonly IKafkaProducer _kafkaProducer;

        public KafkaLicentaClient(IKafkaObserver kafkaObserver,IKafkaProducer kafkaProducer)
        {
            _kafkaObserver = kafkaObserver;
            _kafkaProducer = kafkaProducer;
        }

        internal async Task<string> RunCode(string topicName, CodeRunReqDto req, Func<KafkaDto, Task> callback)
        {
            string opId = Guid.NewGuid().ToString();
            await _kafkaProducer.ProduceAsync(topicName, opId, req);
            await _kafkaObserver.AddNotifier(topicName.Replace("Req", "Resp"), opId, callback);
            return opId;
        }


        internal void RemoveNotifier(string topicName, string opId)
        {
             _kafkaObserver.RemoveNotifier(topicName, opId);
        }
    }
}
