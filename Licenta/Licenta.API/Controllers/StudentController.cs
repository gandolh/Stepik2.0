using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get all students of a course", Description = "")]
        public async Task<IEnumerable<Student>> GetAllByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all students of a teacher", Description = "")]
        public async Task<IEnumerable<Student>> GetAllByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get student by id", Description = "")]
        public async Task<ActionResult<Student>> GetOne(int studentId, bool includeSubmissions)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create student", Description = "")]
        public async Task<CreateResult> Add(Student c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update student", Description = "")]
        public async Task<UpdateResult> Update(Student c)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete student", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
