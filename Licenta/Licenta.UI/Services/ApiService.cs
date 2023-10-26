using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;

namespace Licenta.UI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public IEnumerable<LastAccesedDto> GetAccesedLessons()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<EventDto> GetEvents(DateTime? after = null)
        {
            throw new NotImplementedException();
        }

        public CourseDto? GetCourse(string courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDto> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}
