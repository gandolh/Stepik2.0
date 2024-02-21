using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class CourseService : BaseCrudService<Course, CourseDto, FullCourseDto>
    {
        private readonly UserMapper _userMapper;

        public CourseService(CourseRepository courseRepository) : base(courseRepository, new CourseMapper(), new FullCourseMapper())
        {
            _userMapper = new UserMapper();

        }

        internal override async Task<IEnumerable<FullCourseDto>> GetFullAll()
        {
           return _fullMapper.Map(await ((CourseRepository)_repository).GetFullAll());
        }

        internal override async Task<FullCourseDto?> GetFullOne(int id)
        {
            var course = await ((CourseRepository)_repository).GetFullOne(id);
            if (course == null)
                return null;
            return _fullMapper.Map(course);
        }
    }
}
