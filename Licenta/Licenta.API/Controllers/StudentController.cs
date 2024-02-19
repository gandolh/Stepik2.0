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
    public class StudentController : BaseCrudController<Student,StudentDto>
    {

        public StudentController(StudentService service) : base(service)
        {
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




    }
}
