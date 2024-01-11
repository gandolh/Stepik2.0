using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Course>> GetAll(bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public async Task<IEnumerable<Course>> GetAllByTeacher(int teacherId, bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<Course>> GetOne(int courseId, bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CreateResult> Add(Course c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<UpdateResult> Update(Course c)
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
