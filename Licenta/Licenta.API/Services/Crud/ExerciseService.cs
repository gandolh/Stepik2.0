using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class ExerciseService : BaseCrudService<Exercise, ExerciseDto, FullExerciseDto>
    {

        public ExerciseService(ExerciseRepository repository) : base(repository, new ExerciseMapper(),new FullExerciseMapper())
        {
        }


    }
}
