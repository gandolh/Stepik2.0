using Licenta.SDK.Models.Dtos;
using System.Net;

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

        public async Task<FullCourseDto> GetOneCourse(int courseId)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"courseId", courseId.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<FullCourseDto>(
                _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneCourse),
                querryParameters
                );

            return resp;
        }

        internal async Task<FullLessonDto> GetOneLesson(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"lessonId", id.ToString()},
            };
            var resp = await _myHttpClient.GetAsync<FullLessonDto>(
                _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneLesson),
                querryParameters
                );

            return resp;
        }

      
        internal async Task<UserDto?> GetUser(LoginReqDto reqDto)
        {
                UserDto? resp = await _myHttpClient.PostAsync<UserDto?, LoginReqDto>(
                   _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetUser),
                   reqDto
                   );

                return resp;
        }

        internal async Task<HttpStatusCode> Register(RegisterReqDto reqDto)
        {
            try
            {
                string resp = await _myHttpClient.PostAsync(
                   _licentaConfig.GetPathTo(_licentaConfig.Endpoints.Register),
                   reqDto
                   );

                return HttpStatusCode.OK;

            }catch (Exception ex)
            {
                return HttpStatusCode.Forbidden;
            }
        }
    }
}
