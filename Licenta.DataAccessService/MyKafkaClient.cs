using CertEntTrust.MW.SDK.Models.Communication;
using Licenta.DataAccessService.Config;
using Licenta.DataAccessService.Interfaces;
using Licenta.SDK.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Licenta.DataAccessService
{

    // must pe scoped service
    //todo: rewrite this http in kafka produce  
    public class MyKafkaClient : IDisposable, IMyKafkaClient
    {
        private readonly string _OCCServiceUrl;
        private readonly IEbusListener _ebusListener;
        private readonly RedisClient _redisClient;
        private readonly Dictionary<string, Func<string, Task>> UiNotifiers;
        private readonly string SessionId;


        public MyKafkaClient(IConfiguration iConfig, IEbusListener ebusListener)
        {
            SessionId = Guid.NewGuid().ToString();
            UiNotifiers = new();

            KafkaConfig occConfig = new KafkaConfig(iConfig);
            RedisConfig redisConfig = new RedisConfig(iConfig);
            _ebusListener = ebusListener;
            _redisClient = new RedisClient(redisConfig);
            _ebusListener.Subscribe(SessionId, NotifyResponse);
        }


        public async Task Produce<T>(T req, string topicName, Func<string, Task> callback) where T : IWithTrackDataDto
        {
            string opId = Guid.NewGuid().ToString();
            req.OpId = opId;
            req.SessionId = SessionId;
            UiNotifiers.Add(opId, callback);
            //TODO: POST TO KAFKA
            throw new NotImplementedException();

        }


        public async Task NotifyResponse(KafkaResult resp)
        {
            if (resp.RedisKey != "")
            {
                resp.JsonData = await _redisClient.Get(resp.RedisKey) ?? "";
            }

            await UiNotifiers[resp.OpId].Invoke(resp.JsonData);

        }

        public void Dispose()
        {
            _ebusListener.UnSubscribe(SessionId);
        }
    }
}
