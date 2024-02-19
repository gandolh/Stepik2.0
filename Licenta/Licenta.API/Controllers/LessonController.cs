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
    public class LessonController : BaseCrudController<Lesson,LessonDto>
    {

        public LessonController(LessonService service) : base(service)
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all lessons", Description = "")]
        public async Task<IEnumerable<LessonDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get a lesson by Id.",
            Description = "The response could include exercises of that lesson")]
        public async Task<ActionResult<FullLessonDto>> GetOne(int lessonId)
        {
            var res = await _service.GetOne(lessonId);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
