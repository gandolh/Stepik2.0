using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Mappers
{
    public class CodeEvaluationEntryMapper : BaseMapper<CodeEvaluationEntry, CodeEvaluationEntryDto>
    {
        public override CodeEvaluationEntry Map(CodeEvaluationEntryDto element)
        {
            return new()
            {
                Input= element.Input,
                ExpectedResult = element.ExpectedResult,
            };
        }

        public override CodeEvaluationEntryDto Map(CodeEvaluationEntry element)
        {
            return new()
            {
                Input = element.Input,
                ExpectedResult = element.ExpectedResult,
            };
        }
    }
}
