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
    public class QuizVariantController : ControllerBase
    {
        private readonly QuizVariantService _service;

        public QuizVariantController(QuizVariantService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all quiz variants", Description = "")]
        public async Task<IEnumerable<FullQuizVariantDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get quiz variant by Id",
            Description = "")]
        public async Task<ActionResult<QuizVariantDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update quiz variant", Description = "")]
        public async Task<UpdateResult> Update(QuizVariantDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete quiz variant", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
