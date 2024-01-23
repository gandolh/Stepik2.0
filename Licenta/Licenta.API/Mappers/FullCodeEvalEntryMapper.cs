using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace Licenta.API.Mappers
{
    public class FullCodeEvalEntryMapper : BaseMapper<CodeEvaluationEntry, FullCodeEvaluationEntryDto>
    {
        private readonly ExerciseMapper _exerciseMapper;

        public FullCodeEvalEntryMapper()
        {
            _exerciseMapper = new();
        }

        public override CodeEvaluationEntry Map(FullCodeEvaluationEntryDto element)
        {
            return new()
            {
                Id = element.Id,
                Input = element.Input,
                ExpectedResult = element.ExpectedResult,
                Exercise = _exerciseMapper.Map(element.Exercise)
            };
        }

        public override FullCodeEvaluationEntryDto Map(CodeEvaluationEntry element)
        {
            return new()
            {
                Id = element.Id,
                Input = element.Input,
                ExpectedResult = element.ExpectedResult,
                Exercise = _exerciseMapper.Map(element.Exercise!)
            };
        }
    }
}
