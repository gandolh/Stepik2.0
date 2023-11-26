using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;

namespace Licenta.UI.Services
{
    public class ApiConnectorService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiConnectorService(IHttpClientFactory httpClientFactory)
        {
            
            _httpClient = httpClientFactory.CreateClient("Api");
        }

        public async Task<IEnumerable<LastAccesedDto>> GetAccesedLessons(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<EventDto>> GetEvents(DateTime? after = null)
        {
            throw new NotImplementedException();
        }

        public async Task<CourseDto?> GetCourse(string courseId)
        {
           
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            try
            {
                var resp = await _httpClient.GetAsync(nameof(GetCourses));
            }
            catch (Exception EX)
            {

            }
            throw new NotImplementedException();
        }
    }
}
