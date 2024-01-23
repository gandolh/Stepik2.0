using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _service;

        public ExerciseController(ExerciseService exerciseService)
        {
            _service = exerciseService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all exercises", Description = "")]
        public async Task<IEnumerable<ExerciseDto>> GetAll()
        {
            return await _service.GetAll();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get all exercises of a student", Description = "")]
        public async Task<IEnumerable<Exercise>> GetAllByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all exercises of a lesson", Description = "")]
        public async Task<IEnumerable<Exercise>> GetAllByLesson(int lessonId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get exercise by id",
            Description = "The response could include submissions for that exercise.")]
        public async Task<ActionResult<ExerciseDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create exercise", Description = "")]
        public async Task<CreateResult> Add(ExerciseDto c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update exercise", Description = "")]
        public async Task<UpdateResult> Update(ExerciseDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete exercise", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
