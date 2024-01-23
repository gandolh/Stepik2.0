using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class FullQuizVariantMapper : BaseMapper<FullQuizVariantDto, QuizVariant>
    {
        private readonly ExerciseMapper _exerciseMapper;

        public FullQuizVariantMapper()
        {
            _exerciseMapper = new ExerciseMapper();
        }

        public override FullQuizVariantDto Map(QuizVariant element)
        {
            return new()
            {
                Id= element.Id,
                ExerciseId=element.ExerciseId,
                Text=element.Text,
                IsCorrect=element.IsCorrect,
                Exercise = _exerciseMapper.Map(element.Exercise!)
            };
        }

        public override QuizVariant Map(FullQuizVariantDto element)
        {
            return new()
            {
                Id = element.Id,
                ExerciseId = element.ExerciseId,
                Text = element.Text,
                IsCorrect = element.IsCorrect,
                Exercise = _exerciseMapper.Map(element.Exercise)
            };
        }
    }
}
