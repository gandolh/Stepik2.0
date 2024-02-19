using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class QuizVariantService : BaseCrudService<QuizVariant, QuizVariantDto, FullQuizVariantDto>
    {
        public QuizVariantService(QuizVariantsRepository repository, ExerciseRepository exerciseRepository) 
            : base(repository, new QuizVariantMapper(), new FullQuizVariantMapper())
        {
        }

    }
}
