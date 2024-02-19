using Licenta.API.Models;
using Licenta.API.Services.Crud;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers.Crud
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class QuizVariantController : BaseCrudController<QuizVariant, QuizVariantDto, FullQuizVariantDto>
    {

        public QuizVariantController(QuizVariantService service) : base(service)
        {
        }

        [SwaggerOperation(Summary = "Get all quiz variants", Description = "")]
        public override async Task<IEnumerable<QuizVariantDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get quiz variant by Id", Description = "")]
        public override async Task<ActionResult<QuizVariantDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full quiz variant all", Description = "")]
        public override async Task<IEnumerable<FullQuizVariantDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full quiz variant by Id", Description = "")]
        public override async Task<ActionResult<FullQuizVariantDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update quiz variant", Description = "")]
        public override async Task<UpdateResult> Update(QuizVariantDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Delete quiz variant", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
