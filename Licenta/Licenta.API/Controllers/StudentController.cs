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
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService studentService)
        {
            _service = studentService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all students", Description = "")]
        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get student by Id", Description = "")]
        public async Task<ActionResult<StudentDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }


        [HttpPut]
        [SwaggerOperation(Summary = "Update student", Description = "")]
        public async Task<UpdateResult> Update(StudentDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete student", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }


    }
}
