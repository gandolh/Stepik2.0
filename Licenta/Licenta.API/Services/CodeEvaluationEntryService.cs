using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;
using System.Diagnostics;

namespace Licenta.API.Services
{
    public class CodeEvaluationEntryService
    {
        private readonly CodeEvalEntryRepository _repository;
        private readonly FullCodeEvalEntryMapper _fullMapper;
        private readonly CodeEvalEntryMapper _mapper;
        private readonly ExerciseRepository _exerciseRepository;
        public CodeEvaluationEntryService(CodeEvalEntryRepository repository, ExerciseRepository exerciseRepository)
        {
            _repository = repository;
            _exerciseRepository = exerciseRepository;
            _fullMapper = new();
            _mapper = new();

        }


        internal async Task<IEnumerable<FullCodeEvaluationEntryDto>> GetAll()
        {
           var codeEvals = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            codeEvals.ForEach(codeEvals => codeEvals.Exercise = exercises.Find(ex => ex.Id == codeEvals.ExerciseId));
            return _fullMapper.Map(codeEvals);
        }

        internal async Task<CodeEvaluationEntryDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }

        internal async Task<UpdateResult> Update(CodeEvaluationEntryDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(CodeEvaluationEntryDto), c.Id);
        }
    }
}
