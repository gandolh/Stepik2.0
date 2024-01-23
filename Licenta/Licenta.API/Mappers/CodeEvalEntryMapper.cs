using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class CodeEvalEntryMapper : BaseMapper<CodeEvaluationEntry, CodeEvaluationEntryDto>
    {
        public override CodeEvaluationEntry Map(CodeEvaluationEntryDto element)
        {
            return new()
            {
                Id = element.Id,
                Input = element.Input,
                ExerciseId = element.ExerciseId,
                ExpectedResult = element.ExpectedResult,
            };
        }

        public override CodeEvaluationEntryDto Map(CodeEvaluationEntry element)
        {
            return new()
            {
                Id = element.Id,
                Input = element.Input,
                ExerciseId = element.ExerciseId,
                ExpectedResult = element.ExpectedResult,
            };
        }
    }
}
