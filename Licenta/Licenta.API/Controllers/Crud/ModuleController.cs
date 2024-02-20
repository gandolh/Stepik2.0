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
    public class ModuleController : BaseCrudController<Module, ModuleDto, ModuleDto>
    {

        public ModuleController(ModuleService service) : base(service)
        {
        }

        [SwaggerOperation(Summary = "Get all modules", Description = "")]
        public override async Task<IEnumerable<ModuleDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get module by Id", Description = "")]
        public override async Task<ActionResult<ModuleDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full module all", Description = "")]
        public override async Task<IEnumerable<ModuleDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full module by Id", Description = "")]
        public override async Task<ActionResult<ModuleDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update module", Description = "")]
        public override async Task<UpdateResult> Update(ModuleDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Delete module", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
