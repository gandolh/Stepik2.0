using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class ExerciseMapper : BaseMapper<Exercise, ExerciseDto>
    {
        private readonly QuizVariantMapper _quizVariantMapper;
        private readonly CodeEvaluationEntryMapper _codeEvalMapper;

        public ExerciseMapper()
        {
            _quizVariantMapper = new QuizVariantMapper();
            _codeEvalMapper = new CodeEvaluationEntryMapper();
        }

        public override Exercise Map(ExerciseDto element)
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

        public override ExerciseDto Map(Exercise element)
        {
            return new ExerciseDto()
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
