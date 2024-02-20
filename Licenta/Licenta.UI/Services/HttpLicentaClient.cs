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
            };
            var resp = await _myHttpClient.GetAsync<List<CourseDto>>(
                _licentaConfig.Endpoints.Course.GetAll,
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
                _licentaConfig.Endpoints.Course.GetById,
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
                _licentaConfig.Endpoints.Lesson.GetById,
                querryParameters
                );

            return resp;
        }
        internal async Task<List<FullCodeEvaluationEntryDto>> GetCodeEvaluations()
        {

            var resp = await _myHttpClient.GetAsync<List<FullCodeEvaluationEntryDto>>(
                _licentaConfig.Endpoints.CodeEvaluationEntry.GetAll,
                new Dictionary<string, string>()
                );

            return resp;
        }

        internal async Task<List<ExerciseDto>> GetExercises()
        {
            var resp = await _myHttpClient.GetAsync<List<ExerciseDto>>(
               _licentaConfig.Endpoints.Exercise.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<LessonDto>> GetLessons()
        {
            var resp = await _myHttpClient.GetAsync<List<LessonDto>>(
               _licentaConfig.Endpoints.Lesson.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<ModuleDto>> GetModules()
        {
            var resp = await _myHttpClient.GetAsync<List<ModuleDto>>(
               _licentaConfig.Endpoints.Module.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<FullQuizVariantDto>> GetQuizVariants()
        {
            var resp = await _myHttpClient.GetAsync<List<FullQuizVariantDto>>(
               _licentaConfig.Endpoints.QuizVariant.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<StudentDto>> GetStudents()
        {
            var resp = await _myHttpClient.GetAsync<List<StudentDto>>(
               _licentaConfig.Endpoints.Student.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<TeacherDto>> GetTeachers()
        {
            var resp = await _myHttpClient.GetAsync<List<TeacherDto>>(
               _licentaConfig.Endpoints.Teacher.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<UserDto?> GetUser(LoginReqDto reqDto)
        {
            UserDto? resp = await _myHttpClient.PostAsync<UserDto?, LoginReqDto>(
               _licentaConfig.Endpoints.Account.GetUser,
               reqDto
               );

            return resp;
        }

        internal async Task<HttpStatusCode> Register(RegisterReqDto reqDto)
        {
            try
            {
                string resp = await _myHttpClient.PostAsync(
                   _licentaConfig.Endpoints.Account.Register,
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
              _licentaConfig.Endpoints.CodeEvaluationEntry.GetById,
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
               _licentaConfig.Endpoints.Exercise.GetById,
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
               _licentaConfig.Endpoints.Module.GetById,
               querryParameters
               );

            return resp;
        }

        internal async Task<QuizVariantDto> GetOneQuizVariant(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<QuizVariantDto>(
               _licentaConfig.Endpoints.QuizVariant.GetById,
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
               _licentaConfig.Endpoints.Student.GetById,
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
               _licentaConfig.Endpoints.Teacher.GetById,
               querryParameters
               );

            return resp;
        }

        internal async Task UpdateCodeEvaluation(CodeEvaluationEntryDto? dto)
        {
            await _myHttpClient.PutAsync(
               _licentaConfig.Endpoints.CodeEvaluationEntry.Update,
               dto);

        }
        internal async Task UpdateCourse(CourseDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.Course.Update,
              dto
              );

        }
        internal async Task UpdateExercise(ExerciseDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.Exercise.Update,
              dto
              );

        }
        internal async Task UpdateLesson(LessonDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.Lesson.Update,
              dto);

        }
        internal async Task UpdateModule(ModuleDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.Module.Update,
              dto);

        }
        internal async Task UpdateQuizVariant(QuizVariantDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.QuizVariant.Update,
              dto);

        }
        internal async Task UpdateStudent(StudentDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.Student.Update,
              dto);

        }
        internal async Task UpdateTeacher(TeacherDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.Teacher.Update,
              dto);

        }

        internal async Task DeleteCodeEvaluation(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };

            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.CodeEvaluationEntry.Delete,
              querryParameters);
        }
        internal async Task DeleteCourse(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.Course.Delete,
              querryParameters);
        }
        internal async Task DeleteExercise(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.Exercise.Delete,
              querryParameters);
        }
        internal async Task DeleteLesson(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.Lesson.Delete,
              querryParameters);
        }
        internal async Task DeleteModule(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.Module.Delete,
              querryParameters);
        }
        internal async Task DeleteQuizVariant(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.QuizVariant.Delete,
              querryParameters);
        }
        internal async Task DeleteStudent(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.Student.Delete,
              querryParameters);
        }
        internal async Task DeleteTeacher(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.Teacher.Delete,
              querryParameters);
        }

    }
}
