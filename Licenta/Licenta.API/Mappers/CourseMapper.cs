using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class CourseMapper : BaseMapper<Course, CourseDto>
    {
        private readonly TeacherMapper _teacherMapper;
        private readonly StudentMapper _studentMapper;

        public CourseMapper()
        {
            _teacherMapper = new TeacherMapper();
            _studentMapper = new StudentMapper();
        }

        public override Course Map(CourseDto element)
        {
            return new Course()
            {
                Id = element.Id,
                Name = element.Name,
                Teachers= _teacherMapper.Map(element.Teachers),
                Students= _studentMapper.Map(element.Students)
            };
        }

        public override CourseDto Map(Course element)
        {
            return new CourseDto()
            {
                Id = element.Id,
                Name = element.Name,
                Teachers = _teacherMapper.Map(element.Teachers),
                Students = _studentMapper.Map(element.Students)
            };
        }
    }
}
