using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class LessonMapper : BaseMapper<Lesson, LessonDto>
    {
        public override Lesson Map(LessonDto element)
        {
            return new Lesson()
            {
                Id = element.Id,
                Name = element.Name
            };
        }

        public override LessonDto Map(Lesson element)
        {
            return new LessonDto()
            {
                Id = element.Id,
                Name = element.Name
            };
        }
    }
}
