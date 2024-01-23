using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class FullExerciseMapper : BaseMapper<Exercise, FullExerciseDto>
    {
        private readonly QuizVariantMapper _quizVariantMapper;
        private readonly CodeEvalEntryMapper _codeEvalMapper;

        public FullExerciseMapper()
        {
            _quizVariantMapper = new QuizVariantMapper();
            _codeEvalMapper = new CodeEvalEntryMapper();
        }

        public override Exercise Map(FullExerciseDto element)
        {
            return new Exercise()
            {
                Id=element.Id,
                LessonId =element.LessonId,
                Enunciation=element.Enunciation,
                SampleInput= element.SampleInput,
                Type = element.IsCodeRunner ? ExerciseType.Code : ExerciseType.Quiz,
                QuizVariants = _quizVariantMapper.Map(element.QuizVariants),
                CodeEvaluationEntries = _codeEvalMapper.Map(element.CodeEvaluationEntries)
            };
        }

        public override FullExerciseDto Map(Exercise element)
        {
            return new FullExerciseDto()
            {
                Id = element.Id,
                LessonId = element.LessonId,
                Enunciation = element.Enunciation,
                SampleInput = element.SampleInput,
                IsCodeRunner = element.Type == ExerciseType.Code ? true : false,
                QuizVariants = _quizVariantMapper.Map(element.QuizVariants),
                CodeEvaluationEntries = _codeEvalMapper.Map(element.CodeEvaluationEntries)
            };
        }
    }
}
