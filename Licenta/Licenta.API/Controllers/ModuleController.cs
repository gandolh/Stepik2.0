using Licenta.API.Services;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ModuleController : ControllerBase
    {
        private readonly ModuleService _service;

        public ModuleController(ModuleService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all modules", Description = "")]
        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Module by id",
            Description = "The response could include submissions for that exercise.")]
        public async Task<ActionResult<ModuleDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
