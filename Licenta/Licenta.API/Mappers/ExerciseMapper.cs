using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class ExerciseMapper : BaseMapper<Exercise, ExerciseDto>
    {
        private readonly QuizVariantMapper _quizVariantMapper;

        public ExerciseMapper()
        {
            _quizVariantMapper = new QuizVariantMapper();
        }

        public override Exercise Map(ExerciseDto element)
        {
            return new Exercise()
            {
                Id=element.Id,
                LessonId =element.LessonId,
                Enunciation=element.Enunciation,
                Type = element.IsCodeRunner ? Db.ExerciseType.Code : Db.ExerciseType.Quiz,
                QuizVariants = _quizVariantMapper.Map(element.QuizVariants)
            };
        }

        public override ExerciseDto Map(Exercise element)
        {
            return new ExerciseDto()
            {
                Id = element.Id,
                LessonId = element.LessonId,
                Enunciation = element.Enunciation,
                IsCodeRunner = element.Type == Db.ExerciseType.Code ? true : false,
                QuizVariants = _quizVariantMapper.Map(element.QuizVariants)

            };
        }
    }
}
