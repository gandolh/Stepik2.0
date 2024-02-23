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
    public class LessonController : BaseCrudController<Lesson, LessonDto, FullLessonDto>
    {

        public LessonController(LessonService service) : base(service)
        {
        }

        [SwaggerOperation(Summary = "Get all lessons", Description = "")]
        public override async Task<IEnumerable<LessonDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get lesson by Id", Description = "")]
        public override async Task<ActionResult<LessonDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full lesson all", Description = "")]
        public override async Task<IEnumerable<FullLessonDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full lesson by Id", Description = "")]
        public override async Task<ActionResult<FullLessonDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update lesson", Description = "")]
        public override async Task<UpdateResult> Update(LessonDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Create lesson", Description = "")]
        public override async Task<UpdateResult> Create(LessonDto c)
        {
            return await base.Create(c);
        }
        [SwaggerOperation(Summary = "Delete lesson", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
