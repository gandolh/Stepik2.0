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
    public class CodeEvaluationEntryController : ControllerBase
    {
        private readonly CodeEvaluationEntryService _service;

        public CodeEvaluationEntryController(CodeEvaluationEntryService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all code evals entries", Description = "")]
        public async Task<IEnumerable<FullCodeEvaluationEntryDto>> GetAll()
        {
            return await _service.GetAll();
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

        [HttpPut]
        [SwaggerOperation(Summary = "Update exercise", Description = "")]
        public async Task<UpdateResult> Update(CodeEvaluationEntryDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete exercise", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }

    }
}
