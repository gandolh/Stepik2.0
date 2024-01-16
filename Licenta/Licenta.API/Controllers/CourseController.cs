using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses",
        Description = "Get all courses. The response could include list of participating students" +
            "or teachers")]
        public async Task<IEnumerable<Course>> GetAll(bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses of a teacher",
        Description = "Get all courses of a teacher. The response could include list of participating students" +
            "and all the teachers that teaches that course")]
        public async Task<IEnumerable<Course>> GetAllByTeacher(int teacherId, bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get one course by id",
        Description = "The response could include list of participating students" +
            "and teachers")]
        public async Task<ActionResult<Course>> GetOne(int courseId, bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new course", Description = "")]
        public async Task<CreateResult> Add(Course c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update course", Description = "")]
        public async Task<UpdateResult> Update(Course c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "delete course", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
