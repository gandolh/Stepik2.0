using Licenta.API.Services;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuizVariantController : ControllerBase
    {
        private readonly QuizVariantService _service;

        public QuizVariantController(QuizVariantService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all quiz variants", Description = "")]
        public async Task<IEnumerable<QuizVariantDto>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}
