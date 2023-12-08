namespace Licenta.SDK.Models
{
    public static class ApiEndpoints
    {
        public static BaseEndpointType Courses  = new BaseEndpointType()
        {
            Prefix = "/api/course",
            GetAll=$"/all",
            GetById= $"/one"
        };
    }

    public class BaseEndpointType
    {
        public string Prefix = "";
        public string GetAll = "";
        public string GetById = "";
        public string Create = "";
        public string Update = "";
        public string Delete = "";
    }
}
