using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LessonController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetAllByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetAllByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<Lesson>> GetOne(int lessonId, bool includeExercises)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CreateResult> Add(Lesson c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<UpdateResult> Update(Lesson c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
