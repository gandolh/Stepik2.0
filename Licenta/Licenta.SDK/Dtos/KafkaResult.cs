using Licenta.SDK.Dtos;

namespace CertEntTrust.MW.SDK.Models.Communication
{
    public class KafkaResult : WithTrackDataDto
    {
        public KafkaResult(){}
        public KafkaResult(string sessionId, string opId, string jsonData = "", string redisKey = "")
        {
            SessionId = sessionId;
            OpId = opId;
            JsonData = jsonData;
            RedisKey = redisKey;

        }

        // if data is small
        public string JsonData { get; set; } = "";
        // if data is big
        public string RedisKey { get; set; } = "";

    }
}
