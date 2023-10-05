using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;

namespace Licenta.DataAccessService.Interfaces
{
    public interface IMyKafkaClient
    {
        void Dispose();
        Task NotifyResponse(KafkaResult resp);
        Task Produce<T>(T req, string topicName, Func<string, Task> callback) where T : IWithTrackDataDto;
    }
}