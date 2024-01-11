using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAllByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAllByExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<Teacher>> GetOne(int submissionId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CreateResult> Add(Teacher c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<UpdateResult> Update(Teacher c)
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
