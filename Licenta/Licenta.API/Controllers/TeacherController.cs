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
    public class TeacherController : BaseCrudController<Teacher, TeacherDto>
    {

        public TeacherController(TeacherService service) : base(service) { }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all teachers", Description = "")]
        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            return await _service.GetAll();
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


    }
}
