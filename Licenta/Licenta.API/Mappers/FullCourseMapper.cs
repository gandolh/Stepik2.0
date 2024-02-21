using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using System.Diagnostics;

namespace Licenta.API.Mappers
{
    public class FullCourseMapper : BaseMapper<Course, FullCourseDto>
    {
        private readonly FullModuleMapper _fullModuleMapper;
        private readonly UserMapper _userMapper;

        public FullCourseMapper()
        {
            _fullModuleMapper = new FullModuleMapper();
            _userMapper = new UserMapper();
        }

        public override Course Map(FullCourseDto element)
        {
            return new Course()
            {
                Id = element.Id,
                Name = element.Name,
                Modules = _fullModuleMapper.Map(element.Modules),
                Teachers = _userMapper.Map(element.Teachers),
                Students = _userMapper.Map(element.Students)
            };
        }

        public override FullCourseDto Map(Course element)
        {
            return new FullCourseDto()
            {
                Id = element.Id,
                Name = element.Name,
                Modules = _fullModuleMapper.Map(element.Modules),
                Teachers = _userMapper.Map(element.Teachers),
                Students = _userMapper.Map(element.Students)
            };
        }
    }
}
