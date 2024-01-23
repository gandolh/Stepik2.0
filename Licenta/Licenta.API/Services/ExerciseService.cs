using Licenta.API.Mappers;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class ExerciseService
    {
        private readonly ExerciseRepository _repository;
        private readonly FullExerciseMapper _fullMapper;
        private readonly ExerciseMapper _mapper;


        public ExerciseService(ExerciseRepository exerciseRepository)
        {
            _repository = exerciseRepository;
            _fullMapper = new FullExerciseMapper();
            _mapper = new();
        }

        internal async Task<IEnumerable<ExerciseDto>> GetAll()
        {
            return _fullMapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<ExerciseDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }
    }
}
