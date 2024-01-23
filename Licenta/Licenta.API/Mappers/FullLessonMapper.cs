using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using System.Reflection;
using System.Xml.Linq;

namespace Licenta.API.Mappers
{
    public class FullLessonMapper : BaseMapper<Lesson, FullLessonDto>
    {
        private readonly FullExerciseMapper _exerciseMapper;

        public FullLessonMapper()
        {
            _exerciseMapper = new FullExerciseMapper();
        }

        public override Lesson Map(FullLessonDto element)
        {
            return new Lesson()
            {
                Id = element.Id,
                Name = element.Name,
                Body = element.Body,
                Exercises = _exerciseMapper.Map(element.Exercises)
            };
        }

        public override FullLessonDto Map(Lesson element)
        {
            return new FullLessonDto()
            {
                Id = element.Id,
                Name = element.Name,
                Body = element.Body,
                Exercises = _exerciseMapper.Map(element.Exercises)
            };
        }
    }
}
