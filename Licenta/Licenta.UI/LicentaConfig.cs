
namespace Licenta.UI
{
    public class LicentaConfig
    {

        public LicentaConfig()
        {

        }

        public LicentaConfig(IConfiguration iConfig)
        {
            iConfig.GetSection("LicentaConfig").Bind(this);
        }
        public string UrlApi { get; set; } = string.Empty;
        public KafkaOptions Kafka { get; set; } = new();
        public LicentaEndpoints Endpoints { get; set; } = new();

        internal string GetPathTo(string endpoint)
        {
            return UrlApi + endpoint;
        }
    }

    public class LicentaEndpoints
    {
        public string GetCourses { get; set; } = string.Empty;
        public string GetOneCourse { get; set; } = string.Empty;
        public string GetOneLesson { get; set; } = string.Empty;
        public string GetCoursesByStudent { get; set; } = string.Empty;
        public string Register { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
    }
    public class KafkaOptions
    {
        public string Address { get; set; } = string.Empty;
        public KafkaEndpoints Endpoints { get; set; } = new();
        public string GroupId { get; set; } = string.Empty;
        public List<string> SubscribeTopics { get; set; } = new();
    }

    public class KafkaEndpoints
    {
        public string RunCode { get; set; } = string.Empty;
    }
}

