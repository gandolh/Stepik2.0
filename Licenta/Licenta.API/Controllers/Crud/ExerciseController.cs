using Licenta.API.Models;
using Licenta.API.Services.Crud;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers.Crud
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExerciseController : BaseCrudController<Exercise, ExerciseDto, FullExerciseDto>
    {

        public ExerciseController(ExerciseService service) : base(service)
        {
        }

        [SwaggerOperation(Summary = "Get all exercises", Description = "")]
        public override async Task<IEnumerable<ExerciseDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get exercise by Id", Description = "")]
        public override async Task<ActionResult<ExerciseDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full exercise all", Description = "")]
        public override async Task<IEnumerable<FullExerciseDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full exercise by Id", Description = "")]
        public override async Task<ActionResult<FullExerciseDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update exercise", Description = "")]
        public override async Task<UpdateResult> Update(ExerciseDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Create exercise", Description = "")]
        public override async Task<UpdateResult> Create(ExerciseDto c)
        {
            return await base.Create(c);
        }
        [SwaggerOperation(Summary = "Delete exercise", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
