using Licenta.API.Mappers;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;
using System.Diagnostics;

namespace Licenta.API.Services
{
    public class CodeEvaluationEntryService
    {
        private readonly CodeEvaluationEntryRepository _repository;
        private readonly CodeEvaluationEntryMapper _mapper;
        public CodeEvaluationEntryService(CodeEvaluationEntryRepository repository)
        {
            _repository = repository;
            _mapper = new();

        }


        internal async Task<IEnumerable<CodeEvaluationEntryDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }
    }
}
