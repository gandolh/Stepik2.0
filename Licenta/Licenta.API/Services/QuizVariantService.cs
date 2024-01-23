using Licenta.API.Mappers;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class QuizVariantService
    {
        private readonly QuizVariantsRepository _repository;
        private readonly ExerciseRepository _exerciseRepository;
        private readonly FullQuizVariantMapper _mapper;

        public QuizVariantService(QuizVariantsRepository repository, ExerciseRepository exerciseRepository)
        {
            _repository = repository;
            _exerciseRepository = exerciseRepository;
            _mapper = new FullQuizVariantMapper();
        }

        internal async Task<IEnumerable<FullQuizVariantDto>> GetAll()
        {
            var quizVariants = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            quizVariants.ForEach(quizVariant => quizVariant.Exercise = exercises.Find(ex => ex.Id == quizVariant.ExerciseId));
            return _mapper.Map(quizVariants);
        }

        internal async Task<QuizVariantDto> GetOne(int id)
        {
            return _mapper.Map(await _repository.GetOneAsync(id));
        }
    }
}
