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

        public async Task<List<CourseDto>> GetCourses()
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

        public async Task<List<FullCourseDto>> GetFullCourses()
        {
            var querryParameters = new Dictionary<string, string>()
            {
            };
            var resp = await _myHttpClient.GetAsync<List<FullCourseDto>>(
                _licentaConfig.Endpoints.Course.GetFullAll,
                querryParameters
                );

            return resp;
        }

        public async Task<CourseDto> GetOneCourse(int courseId)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id", courseId.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<FullCourseDto>(
                _licentaConfig.Endpoints.Course.GetById,
                querryParameters
                );

            return resp;
        }


        public async Task<FullCourseDto> GetFullOneCourse(int courseId)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id", courseId.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<FullCourseDto>(
                _licentaConfig.Endpoints.Course.GetFullById,
                querryParameters
                );

            return resp;
        }


        internal async Task<LessonDto> GetOneLesson(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id", id.ToString()},
            };
            var resp = await _myHttpClient.GetAsync<LessonDto>(
                _licentaConfig.Endpoints.Lesson.GetById,
                querryParameters
                );

            return resp;
        }

        internal async Task<FullLessonDto> GetFullOneLesson(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id", id.ToString()},
            };
            var resp = await _myHttpClient.GetAsync<FullLessonDto>(
                _licentaConfig.Endpoints.Lesson.GetFullById,
                querryParameters
                );

            return resp;
        }
        internal async Task<List<CodeEvaluationEntryDto>> GetCodeEvaluations()
        {

            var resp = await _myHttpClient.GetAsync<List<CodeEvaluationEntryDto>>(
                _licentaConfig.Endpoints.CodeEvaluationEntry.GetAll,
                new Dictionary<string, string>()
                );

            return resp;
        }

        internal async Task<List<FullCodeEvaluationEntryDto>> GetFullCodeEvaluations()
        {

            var resp = await _myHttpClient.GetAsync<List<FullCodeEvaluationEntryDto>>(
                _licentaConfig.Endpoints.CodeEvaluationEntry.GetFullAll,
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

        internal async Task<List<FullLessonDto>> GetFullLessons()
        {
            var resp = await _myHttpClient.GetAsync<List<FullLessonDto>>(
               _licentaConfig.Endpoints.Lesson.GetFullAll,
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

        internal async Task<List<QuizVariantDto>> GetQuizVariants()
        {
            var resp = await _myHttpClient.GetAsync<List<QuizVariantDto>>(
               _licentaConfig.Endpoints.QuizVariant.GetAll,
               new Dictionary<string, string>()
               );

            return resp;
        }
        internal async Task<List<FullQuizVariantDto>> GetFullQuizVariants()
        {
            var resp = await _myHttpClient.GetAsync<List<FullQuizVariantDto>>(
               _licentaConfig.Endpoints.QuizVariant.GetFullAll,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<PortalUserDto>> GetStudents()
        {
            var resp = await _myHttpClient.GetAsync<List<PortalUserDto>>(
               _licentaConfig.Endpoints.User.GetAllStudents,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<List<PortalUserDto>> GetTeachers()
        {
            var resp = await _myHttpClient.GetAsync<List<PortalUserDto>>(
               _licentaConfig.Endpoints.User.GetAllTeachers,
               new Dictionary<string, string>()
               );

            return resp;
        }

        internal async Task<OptInNotificationDto> GetOptInNotifications(int userId)
        {
            var resp = await _myHttpClient.GetAsync<OptInNotificationDto>(
               _licentaConfig.Endpoints.Account.GetOptInNotifications,
               new Dictionary<string, string>() { { "userId", userId.ToString() } }
               );

            return resp;
        }




        internal async Task<PortalUserDto?> GetUser(LoginReqDto reqDto)
        {
            PortalUserDto? resp = await _myHttpClient.PostAsync<PortalUserDto?, LoginReqDto>(
               _licentaConfig.Endpoints.Account.GetUser,
               reqDto
               );

            return resp;
        }
        
        internal async Task<string> GetProfilePicture(string email)
        {
            string resp = await _myHttpClient.GetAsync(
               _licentaConfig.Endpoints.Account.GetProfilePicture,
                  new Dictionary<string, string>() { { "email", email } }
               );

            return resp;
        }

        internal async Task<HttpStatusCode> PostProfilePicture(IFormFile formFile, string email)
        {
            Stream stream = formFile.OpenReadStream();
            MultipartFormDataContent content = new MultipartFormDataContent
            {
                { new StreamContent(stream), "formFile", formFile.FileName },
                { new StringContent(email), "email"}
            };
            HttpStatusCode resp = await _myHttpClient.PostAsync<HttpStatusCode>(
               _licentaConfig.Endpoints.Account.PostProfilePicture,
               content
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
                {"id",id.ToString()},
            };
            var resp = await _myHttpClient.GetAsync<QuizVariantDto>(
               _licentaConfig.Endpoints.QuizVariant.GetById,
               querryParameters
               );

            return resp;
        }

        internal async Task<PortalUserDto> GetOneStudent(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<PortalUserDto>(
               _licentaConfig.Endpoints.User.GetById,
               querryParameters
               );

            return resp;
        }

        internal async Task<PortalUserDto> GetOneTeacher(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            var resp = await _myHttpClient.GetAsync<PortalUserDto>(
               _licentaConfig.Endpoints.User.GetById,
               querryParameters
               );

            return resp;
        }


        internal async Task UpdatePortalUser(PortalUserDto? dto)
        {
            await _myHttpClient.PutAsync(
               _licentaConfig.Endpoints.Account.Update,
               dto);

        }

        internal async Task UpdateOptInNotifications(OptInNotificationDto? dto)
        {
            await _myHttpClient.PutAsync(
               _licentaConfig.Endpoints.Account.UpdateOptInNotifications,
               dto);
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
        internal async Task UpdateTeacher(PortalUserDto? dto)
        {
            await _myHttpClient.PutAsync(
              _licentaConfig.Endpoints.User.Update,
              dto);

        }

        internal async Task CreateCourse(CourseDto dto)
        {
            await _myHttpClient.PostAsync(
              _licentaConfig.Endpoints.Course.Create,
              dto);
        }

        internal async Task CreateExercise(ExerciseDto dto)
        {
            await _myHttpClient.PostAsync(
              _licentaConfig.Endpoints.Exercise.Create,
              dto);
        }

        internal async Task CreateLesson(LessonDto dto)
        {
            await _myHttpClient.PostAsync(
              _licentaConfig.Endpoints.Lesson.Create,
              dto);
        }

        internal async Task CreateModule(ModuleDto dto)
        {
            await _myHttpClient.PostAsync(
              _licentaConfig.Endpoints.Module.Create,
              dto);
        }

        internal async Task CreateQuizVariant(QuizVariantDto dto)
        {
            await _myHttpClient.PostAsync(
              _licentaConfig.Endpoints.QuizVariant.Create,
              dto);
        }

        internal async Task CreateCodeEvaluationEntry(CodeEvaluationEntryDto dto)
        {
            await _myHttpClient.PostAsync(
              _licentaConfig.Endpoints.CodeEvaluationEntry.Create,
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
              _licentaConfig.Endpoints.User.Delete,
              querryParameters);
        }
        internal async Task DeleteTeacher(int id)
        {
            var querryParameters = new Dictionary<string, string>()
            {
                {"id",id.ToString() },
            };
            await _myHttpClient.DeleteAsync(
              _licentaConfig.Endpoints.User.Delete,
              querryParameters);
        }

       
    }
}
