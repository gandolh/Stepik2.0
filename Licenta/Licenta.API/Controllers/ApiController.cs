using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Mapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly IConfiguration _iConfig;
        public ApiController(IConfiguration iConfig){
            _iConfig = iConfig;

        }

        [HttpGet(nameof(GetCourse))]
        public async Task<CourseDto?> GetCourse(string courseId)
        {
            CourseRepository cr = new CourseRepository(conn);
            Course course = cr.GetOne(courseId);
            MapperBase<Course, CourseDto> mapper = new CourseMapper();
            CourseDto dto = mapper.Map(course,
                (course) => course.LastAccesedLesson = null);

            // TODO: add from LastAccesedRepository
            return dto;
        }



    }
}
