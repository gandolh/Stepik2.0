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
    public class TeacherController : ControllerBase
    {
        private readonly TeacherService _service;

        public TeacherController(TeacherService teacherService)
        {
            _service = teacherService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all teachers", Description = "")]
        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all teachers for a student", Description = "")]
        public async Task<IEnumerable<Teacher>> GetAllByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get teacher by Id", Description = "")]
        public async Task<ActionResult<TeacherDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
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
