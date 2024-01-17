namespace Licenta.Runner
{
    public class KafkaOptions
    {
        public string Address { get; set; } = string.Empty;
        public List<string> SubscribeTopics { get; set; } = new();

        public EndpointsResponse Endpoints { get; set; } = new();
    }

    public class EndpointsResponse()
    {
        public string RunCode { get; set; } = string.Empty;
    }
}
