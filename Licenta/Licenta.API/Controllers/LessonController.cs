using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LessonController : ControllerBase
    {
        private readonly LessonService _lessonService;

        public LessonController(LessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all lessons of a course", Description = "")]
        public async Task<IEnumerable<Lesson>> GetAllByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all lessons of a teacher", Description = "")]
        public async Task<IEnumerable<Lesson>> GetAllByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get a lesson by id.",
            Description = "The response could include exercises of that lesson")]
        public async Task<ActionResult<Lesson>> GetOne(int lessonId, bool includeExercises)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create lesson", Description = "")]
        public async Task<CreateResult> Add(Lesson c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update lesson", Description = "")]
        public async Task<UpdateResult> Update(Lesson c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete lesson", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
