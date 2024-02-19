using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class CourseService : BaseCrudService<Course, CourseDto, FullCourseDto>
    {
        private readonly TeacherMapper _teacherMapper;

        public CourseService(CourseRepository courseRepository) : base(courseRepository, new CourseMapper(), new FullCourseMapper())
        {
            _teacherMapper = new TeacherMapper();

        }

    }
}
