using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class QuizVariantService
    {
        private readonly QuizVariantsRepository _repository;
        private readonly ExerciseRepository _exerciseRepository;
        private readonly FullQuizVariantMapper _fullMapper;
        private readonly QuizVariantMapper _mapper;

        public QuizVariantService(QuizVariantsRepository repository, ExerciseRepository exerciseRepository)
        {
            _repository = repository;
            _exerciseRepository = exerciseRepository;
            _fullMapper = new FullQuizVariantMapper();
            _mapper = new();
        }

        internal async Task<IEnumerable<FullQuizVariantDto>> GetAll()
        {
            var quizVariants = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            quizVariants.ForEach(quizVariant => quizVariant.Exercise = exercises.Find(ex => ex.Id == quizVariant.ExerciseId));
            return _fullMapper.Map(quizVariants);
        }

        internal async Task<QuizVariantDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }

        internal async Task<UpdateResult> Update(QuizVariantDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(QuizVariantDto), c.Id);
        }
    }
}
