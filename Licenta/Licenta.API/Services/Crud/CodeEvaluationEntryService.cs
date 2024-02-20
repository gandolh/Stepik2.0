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

        internal override async Task<IEnumerable<FullCodeEvaluationEntryDto>> GetFullAll()
        {
            var codeEvals = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            codeEvals.ForEach(codeEvals => codeEvals.Exercise = exercises.Find(ex => ex.Id == codeEvals.ExerciseId));
            return _fullMapper.Map(codeEvals);
        }


        internal override async Task<FullCodeEvaluationEntryDto?> GetFullOne(int id)
        {
            var codeEval = await _repository.GetOneAsync(id);
            if(codeEval == null)
                return null;
            var exercises = await _exerciseRepository.GetAllAsync();
            codeEval.Exercise = exercises.Find(ex => ex.Id == codeEval.ExerciseId);
            return _fullMapper.Map(codeEval);
        }
    }
}
