using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class QuizVariantMapper : BaseMapper<QuizVariant, QuizVariantDto>
    {
        public override QuizVariant Map(QuizVariantDto element)
        {
            return new QuizVariant()
            {
                Id= element.Id,
                ExerciseId= element.ExerciseId,
                Text= element.Text,
                IsCorrect= element.IsCorrect
            };
        }

        public override QuizVariantDto Map(QuizVariant element)
        {
            return new QuizVariantDto()
            {
                Id = element.Id,
                ExerciseId = element.ExerciseId,
                Text = element.Text,
                IsCorrect = element.IsCorrect
            };
        }
    }
}
