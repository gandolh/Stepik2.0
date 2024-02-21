using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class CourseMapper : BaseMapper<Course, CourseDto>
    {
        private readonly UserMapper _userMapper;

        public CourseMapper()
        {
            _userMapper = new UserMapper();
        }

        public override Course Map(CourseDto element)
        {
            return new Course()
            {
                Id = element.Id,
                Name = element.Name,
                //Teachers= _userMapper.Map(element.Teachers),
                //Students= _userMapper.Map(element.Students)
            };
        }

        public override CourseDto Map(Course element)
        {
            return new CourseDto()
            {
                Id = element.Id,
                Name = element.Name,
                //Teachers = _userMapper.Map(element.Teachers),
                //Students = _userMapper.Map(element.Students)
            };
        }
    }
}
