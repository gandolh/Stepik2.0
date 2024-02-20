using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class QuizVariantService : BaseCrudService<QuizVariant, QuizVariantDto, FullQuizVariantDto>
    {
        private readonly ExerciseRepository _exerciseRepository;

        public QuizVariantService(QuizVariantsRepository repository, ExerciseRepository exerciseRepository)
            : base(repository, new QuizVariantMapper(), new FullQuizVariantMapper())
        {

            _exerciseRepository = exerciseRepository;
        }

        internal override async Task<IEnumerable<FullQuizVariantDto>> GetFullAll()
        {
            var quizVariants = await _repository.GetAllAsync();
            var exercises = await _exerciseRepository.GetAllAsync();
            quizVariants.ForEach(quizVariant => quizVariant.Exercise = exercises.Find(ex => ex.Id == quizVariant.ExerciseId));
            return _fullMapper.Map(quizVariants);
        }

        internal override async Task<FullQuizVariantDto?> GetFullOne(int id)
        {
            var quizVariant = await _repository.GetOneAsync(id);
            if (quizVariant == null)
                return null;
            var exercises = await _exerciseRepository.GetAllAsync();
            quizVariant.Exercise = exercises.Find(ex => ex.Id == quizVariant.ExerciseId);
            return _fullMapper.Map(quizVariant);
        }
    }
}
