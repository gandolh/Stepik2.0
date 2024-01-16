using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubmissionController : ControllerBase
    {
        private readonly SubmissionService _submissionService;

        public SubmissionController(SubmissionService submissionService)
        {
            _submissionService = submissionService;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get all submissions of a student", Description = "")]
        public async Task<IEnumerable<Submission>> GetAllByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all submissions of an exercise", Description = "")]
        public async Task<IEnumerable<Submission>> GetAllByExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get one submission by id", Description = "")]
        public async Task<ActionResult<Submission>> GetOne(int submissionId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create submission", Description = "")]
        public async Task<CreateResult> Add(Submission c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update submission", Description = "")]
        public async Task<UpdateResult> Update(Submission c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete submission", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
