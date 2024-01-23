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

        public async Task<List<CourseDto>> GetCourses(string email, bool includeTeachers = false, bool includeStudents = false)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"includeStudents",includeTeachers.ToString() },
                {"includeTeachers", includeStudents.ToString() },
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
        internal async Task<List<FullCodeEvaluationEntryDto>> GetCodeEvaluations()
        {

            var resp = await _myHttpClient.GetAsync<List<FullCodeEvaluationEntryDto>>(
                _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetCodeEvaluations),
                new Dictionary<string, string>()
                );

            return resp;
        }

        internal async Task<List<ExerciseDto>> GetExercises()
        {
            var resp = await _myHttpClient.GetAsync<List<ExerciseDto>>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetExercises),
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<LessonDto>> GetLessons()
        {
            var resp = await _myHttpClient.GetAsync<List<LessonDto>>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetLessons),
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<ModuleDto>> GetModules()
        {
            var resp = await _myHttpClient.GetAsync<List<ModuleDto>>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetModules),
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<FullQuizVariantDto>> GetQuizVariants()
        {
            var resp = await _myHttpClient.GetAsync<List<FullQuizVariantDto>>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetQuizVariants),
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<StudentDto>> GetStudents()
        {
            var resp = await _myHttpClient.GetAsync<List<StudentDto>>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetStudents),
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<TeacherDto>> GetTeachers()
        {
            var resp = await _myHttpClient.GetAsync<List<TeacherDto>>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetTeachers),
               new Dictionary<string, string>()
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

            }
            catch (Exception ex)
            {
                return HttpStatusCode.Forbidden;
            }
        }

        internal async Task<CodeEvaluationEntryDto> GetOneCodeEvaluation(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };

            var resp = await _myHttpClient.GetAsync<CodeEvaluationEntryDto>(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneCodeEvaluation),
              querryParameters
              );

            return resp;
        }

        internal async Task<ExerciseDto> GetOneExercise(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<ExerciseDto>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneExercise),
               querryParameters
               );

            return resp;
        }


        internal async Task<ModuleDto> GetOneModule(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<ModuleDto>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneModule),
               querryParameters
               );

            return resp;
        }

        internal async Task<FullQuizVariantDto> GetOneQuizVariant(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<FullQuizVariantDto>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneQuizVariant),
               querryParameters
               );

            return resp;
        }

        internal async Task<StudentDto> GetOneStudent(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<StudentDto>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneStudent),
               querryParameters
               );

            return resp;
        }

        internal async Task<TeacherDto> GetOneTeacher(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<TeacherDto>(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.GetOneTeacher),
               querryParameters
               );

            return resp;
        }

        internal async Task UpdateCodeEvaluation(CodeEvaluationEntryDto? dto)
        {
            await _myHttpClient.PutAsync(
               _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateCodeEvaluation),
               dto);

        }

        internal async Task UpdateCourse(CourseDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateCourse),
              dto
              );

        }

        internal async Task UpdateExercise(ExerciseDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateExercise),
              dto
              );

        }

        internal async Task UpdateLesson(LessonDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateLesson),
              dto);

        }

        internal async Task UpdateModule(ModuleDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateModule),
              dto);

        }

        internal async Task UpdateQuizVariant(QuizVariantDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateQuizVariant),
              dto);

        }

        internal async Task UpdateStudent(StudentDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateStudent),
              dto);

        }

        internal async Task UpdateTeacher(TeacherDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.GetPathTo(_licentaConfig.Endpoints.UpdateTeacher),
              dto);

        }
    }
}
