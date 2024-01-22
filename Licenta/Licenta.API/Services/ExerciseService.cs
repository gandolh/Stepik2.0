using Licenta.API.Mappers;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class ExerciseService
    {
        private readonly ExerciseRepository _repository;
        private readonly ExerciseMapper _mapper;

        public ExerciseService(ExerciseRepository exerciseRepository)
        {
            _repository = exerciseRepository;
            _mapper = new ExerciseMapper();
        }

        internal async Task<IEnumerable<ExerciseDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }
    }
}
