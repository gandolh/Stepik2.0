using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Services
{
    public class HttpLicentaClient
    {
        private readonly MyHttpClient _myHttpClient;

        public HttpLicentaClient(MyHttpClient myHttpClient)
        {
            _myHttpClient = myHttpClient;
        }

        public async Task<List<CourseDto>> GetCourses(string email)
        {
            _myHttpClient.GetAsync();
            throw new NotImplementedException();
        }

    }
}
