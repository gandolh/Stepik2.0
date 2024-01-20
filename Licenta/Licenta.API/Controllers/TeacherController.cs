using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get all teachers", Description = "")]
        public async Task<IEnumerable<Teacher>> GetAll(int exerciseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all teachers for a student", Description = "")]
        public async Task<IEnumerable<Teacher>> GetAllByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get teacher by Id", Description = "")]
        public async Task<ActionResult<Teacher>> GetOne(int teacherId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create teacher", Description = "")]
        public async Task<CreateResult> Add(Teacher c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update teacher", Description = "")]
        public async Task<UpdateResult> Update(Teacher c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete teacher", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
