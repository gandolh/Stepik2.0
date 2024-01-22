using Licenta.API.Services;
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
    }
}
