using Licenta.API.Models;
using Licenta.API.Services.Crud;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers.Crud
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CodeEvaluationEntryController : BaseCrudController<CodeEvaluationEntry, CodeEvaluationEntryDto, FullCodeEvaluationEntryDto>
    {
        public CodeEvaluationEntryController(CodeEvaluationEntryService service) : base(service)
        {
        }


        [SwaggerOperation(Summary = "Get all code evals", Description = "")]
        public override async Task<IEnumerable<CodeEvaluationEntryDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get code eval by Id", Description = "")]
        public override async Task<ActionResult<CodeEvaluationEntryDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full code eval all", Description = "")]
        public override async Task<IEnumerable<FullCodeEvaluationEntryDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full code eval by Id", Description = "")]
        public override async Task<ActionResult<FullCodeEvaluationEntryDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update code eval", Description = "")]
        public override async Task<UpdateResult> Update(CodeEvaluationEntryDto c)
        {
            return await base.Update(c);    
        }
        [SwaggerOperation(Summary = "Create code eval", Description = "")]
        public override async Task<UpdateResult> Create(CodeEvaluationEntryDto c)
        {
            return await base.Create(c);
        }

        [SwaggerOperation(Summary = "Delete code eval", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }


    }
}
