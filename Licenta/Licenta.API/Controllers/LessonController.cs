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
    public class LessonController : ControllerBase
    {
        private readonly LessonService _service;

        public LessonController(LessonService lessonService)
        {
            _service = lessonService;
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


        [HttpPut]
        [SwaggerOperation(Summary = "Update lesson", Description = "")]
        public async Task<UpdateResult> Update(LessonDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete lesson", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }


    }
}
