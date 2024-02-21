using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class FullModuleMapper : BaseMapper<Module, FullModuleDto>
    {
        private readonly FullLessonMapper _fullLessonMapper;

        public FullModuleMapper()
        {
            _fullLessonMapper = new FullLessonMapper();
        }

        public override Module Map(FullModuleDto element)
        {
            return new Module()
            {
                Id = element.Id,
                Name = element.Name,
                Lessons = _fullLessonMapper.Map(element.Lessons)
            };
        }

        public override FullModuleDto Map(Module element)
        {
            return new FullModuleDto()
            {
                Id = element.Id,
                Name = element.Name,
                Lessons = _fullLessonMapper.Map(element.Lessons)
            };
        }
    }
}
