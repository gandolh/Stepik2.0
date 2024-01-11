using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ExerciseController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Submission>> GetAllByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<Submission>> GetAllByExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<Submission>> GetOne(int submissionId, bool includeSubmissions)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CreateResult> Add(Submission c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<UpdateResult> Update(Submission c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
