using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using System.Diagnostics;

namespace Licenta.API.Mappers
{
    public class FullCourseMapper : BaseMapper<Course, FullCourseDto>
    {
        private readonly ModuleMapper _moduleMapper;

        public FullCourseMapper()
        {
            _moduleMapper = new ModuleMapper();
        }

        public override Course Map(FullCourseDto element)
        {
            return new Course()
            {
                Id = element.Id,
                Name = element.Name,
                Modules = _moduleMapper.Map(element.Modules)
            };
        }

        public override FullCourseDto Map(Course element)
        {
            return new FullCourseDto()
            {
                Id = element.Id,
                Name = element.Name, 
                Modules = _moduleMapper.Map(element.Modules)
            };
        }
    }
}
