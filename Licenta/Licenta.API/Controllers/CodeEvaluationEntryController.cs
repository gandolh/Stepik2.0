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
        public async Task<IEnumerable<CodeEvaluationEntryDto>> GetAll()
        {
            return await _service.GetAll();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get code eval entry by Id",
            Description = "")]
        public async Task<ActionResult<CodeEvaluationEntryDto>> GetOne()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create exercise", Description = "")]
        public async Task<CreateResult> Add(CodeEvaluationEntryDto c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update exercise", Description = "")]
        public async Task<UpdateResult> Update(CodeEvaluationEntryDto c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete exercise", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
