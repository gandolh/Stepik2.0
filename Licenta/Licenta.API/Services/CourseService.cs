
using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class CourseService : BaseCrudService<Course, CourseDto>
    {
        private readonly FullCourseMapper _fullMapper;
        private readonly TeacherMapper _teacherMapper;

        public CourseService(CourseRepository courseRepository) : base(courseRepository, new CourseMapper())
        {
            _fullMapper = new FullCourseMapper();
            _teacherMapper = new TeacherMapper();

        }

        internal async Task<List<CourseDto>> GetAll(bool includeStudents, bool includeTeachers)
        {
            var courses = await ((CourseRepository)_repository).GetDetailedAsync(includeStudents, includeTeachers);
            var dtos = _mapper.Map(courses);
            return dtos;
        }

        internal async Task<FullCourseDto?> GetFullOne(int courseId)
        {
            Course? course =  await ((CourseRepository)_repository).GetJoinedCourse(courseId);
            if (course == null)
                return null;
            var dto = _fullMapper.Map(course);
            return dto;
        }

    }
}
