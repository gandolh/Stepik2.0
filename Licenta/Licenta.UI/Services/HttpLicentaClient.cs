using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Services
{
    public class HttpLicentaClient
    {
        private readonly MyHttpClient _myHttpClient;
        private readonly LicentaConfig _licentaConfig;

        public HttpLicentaClient(MyHttpClient myHttpClient, LicentaConfig licentaConfig)
        {
            _myHttpClient = myHttpClient;
            _licentaConfig = licentaConfig;
        }

        public async Task<List<CourseDto>> GetCourses(string email)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"includeStudents","false" },
                {"includeTeachers","false" },
            };
            var resp = await _myHttpClient.GetAsync<List<CourseDto>>(
                _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetCoursesByStudent),
                querryParameters
                );

            return resp;
        }

    }
}
