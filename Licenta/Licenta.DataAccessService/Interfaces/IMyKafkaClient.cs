using Licenta.SDK.Dtos;
using Licenta.SDK.Interfaces;

namespace Licenta.DataAccessService.Interfaces
{
    public interface IMyKafkaClient
    {
        void Dispose();
        Task NotifyResponse(KafkaResult resp);
        Task Produce<T>(T req, string topicName, Func<string, Task> callback) where T : IWithTrackDataDto;
    }
}