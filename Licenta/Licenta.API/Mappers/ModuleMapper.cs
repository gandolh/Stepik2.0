using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class ModuleMapper : BaseMapper<Module, ModuleDto>
    {
        private readonly LessonMapper _lessonMapper;

        public ModuleMapper()
        {
            _lessonMapper = new LessonMapper();
        }

        public override Module Map(ModuleDto element)
        {
            return new Module()
            {
                Id = element.Id,
                Name = element.Name,
                Lessons = _lessonMapper.Map(element.Lessons)
            };
        }

        public override ModuleDto Map(Module element)
        {
            return new ModuleDto()
            {
                Id = element.Id,
                Name = element.Name,
                Lessons = _lessonMapper.Map(element.Lessons)
            };
        }
    }
}
