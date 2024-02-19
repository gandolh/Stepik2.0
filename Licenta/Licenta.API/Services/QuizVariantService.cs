using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class QuizVariantService : BaseCrudService<QuizVariant, QuizVariantDto>
    {
        private readonly ExerciseRepository _exerciseRepository;
        private readonly FullQuizVariantMapper _fullMapper;

        public QuizVariantService(QuizVariantsRepository repository, ExerciseRepository exerciseRepository) : base(repository, new QuizVariantMapper())
        {
            _exerciseRepository = exerciseRepository;
            _fullMapper = new FullQuizVariantMapper();
        }

        internal async Task<IEnumerable<FullQuizVariantDto>> GetAll()
        {
            var quizVariants = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            quizVariants.ForEach(quizVariant => quizVariant.Exercise = exercises.Find(ex => ex.Id == quizVariant.ExerciseId));
            return _fullMapper.Map(quizVariants);
        }

    }
}
