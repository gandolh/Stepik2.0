namespace Licenta.UI
{
    public class LicentaConfig
    {
        public string ApiPath { get; set; } = string.Empty;
        public LicentaEndpoints Endpoints { get; set; } = new();

    }

    public class LicentaEndpoints
    {
        public string GetCourses { get; set;} = string.Empty;
    }
}
