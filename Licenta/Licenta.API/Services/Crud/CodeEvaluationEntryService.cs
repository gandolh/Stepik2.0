using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class CodeEvaluationEntryService : BaseCrudService<CodeEvaluationEntry, CodeEvaluationEntryDto, FullCodeEvaluationEntryDto>
    {
        private readonly ExerciseRepository _exerciseRepository;
        public CodeEvaluationEntryService(CodeEvalEntryRepository repository, ExerciseRepository exerciseRepository)
            : base(repository, new CodeEvalEntryMapper(), new FullCodeEvalEntryMapper())
        {
            _exerciseRepository = exerciseRepository;
        }

        internal async Task<IEnumerable<FullCodeEvaluationEntryDto>> GetAll()
        {
            var codeEvals = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            codeEvals.ForEach(codeEvals => codeEvals.Exercise = exercises.Find(ex => ex.Id == codeEvals.ExerciseId));
            return _fullMapper.Map(codeEvals);
        }

    }
}
