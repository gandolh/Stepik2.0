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
    public class CodeEvaluationEntryController : BaseCrudController<CodeEvaluationEntry, CodeEvaluationEntryDto>
    {

        public CodeEvaluationEntryController(CodeEvaluationEntryService service) : base(service)
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all code evals entries", Description = "")]
        public async Task<IEnumerable<FullCodeEvaluationEntryDto>> GetAll()
        {
            return await ((CodeEvaluationEntryService)_service).GetAll();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get code eval entry by id",
            Description = "")]
        public async Task<ActionResult<CodeEvaluationEntryDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }



    }
}
