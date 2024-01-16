
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
        public LicentaEndpoints Endpoints { get; set; } = new();

        internal string GetPathTo(string endpoint)
        {
            return UrlApi + endpoint;
        }
    }

    public class LicentaEndpoints
    {
        public string GetCourses { get; set;} = string.Empty;
        public string GetOne { get; set;} = string.Empty;
        public string GetCoursesByStudent { get; set;} = string.Empty;
    }
}
