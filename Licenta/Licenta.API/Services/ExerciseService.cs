using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class ExerciseService :BaseCrudService<Exercise, ExerciseDto>
    {
        private readonly FullExerciseMapper _fullMapper;

        public ExerciseService(ExerciseRepository repository) : base(repository, new FullExerciseMapper)
        {
            _fullMapper = new FullExerciseMapper();
        }


    }
}
