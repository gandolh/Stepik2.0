using Licenta.API.Mappers;
using Licenta.Db.Data;
using Licenta.Db.Repository;
using Licenta.Sdk.Models.Dtos;
using Licenta.Sdk.Models.Interfaces;
using Licenta.Sdk.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase, IApiService, IDisposable
    {
        private readonly IConfiguration _iConfig;
        private readonly NpgsqlConnection conn;
        public ApiController(IConfiguration iConfig){
            _iConfig = iConfig;
            conn = new NpgsqlConnection(_iConfig["AppConfig:ConnectionString"]);

        }

        

        [HttpGet(nameof(GetAccesedLessons))]
        public IEnumerable<LastAccesedDto> GetAccesedLessons(string userId)
        {
            conn.Open();
            LastAccesedRepository lar = new LastAccesedRepository(conn);
            IEnumerable<LastAccesed> lasts =  lar.GetAll(userId: userId);
            LastAccesedMapper mapper = new();
            IEnumerable<LastAccesedDto> dtos = mapper.Map(lasts);
            return dtos;

        }

        [HttpGet(nameof(GetCourse))]
        public CourseDto? GetCourse(string courseId)
        {
            CourseRepository cr = new CourseRepository(conn);
            Course course = cr.GetOne(courseId);
            MapperBase<Course, CourseDto> mapper = new CourseMapper();
            CourseDto dto = mapper.Map(course, 
                (course) => course.LastAccesedLesson = null);

            // TODO: add from LastAccesedRepository
            return dto;
        }

        [HttpGet(nameof(GetCourses))]
        public IEnumerable<CourseDto> GetCourses()
        {
            CourseRepository cr = new CourseRepository(conn);
            IEnumerable<Course> courses = cr.GetAll();
            MapperBase<Course, CourseDto> mapper = new CourseMapper();
            IEnumerable<CourseDto> dtos = mapper.Map(courses);
            return dtos;
        }

        [HttpGet(nameof(GetEvents))]
        public IEnumerable<EventDto> GetEvents(DateTime? after = null)
        {
            EventRepository er = new EventRepository(conn);
            IEnumerable<Event> events = er.GetAll();
            MapperBase<Event, EventDto> mapper = new EventMapper();
            var dto = mapper.Map(events);
            return dto;
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
