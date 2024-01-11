using Licenta.API.Models;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllByCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllByTeacher(int teacherId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<Student>> GetOne(int studentId, bool includeSubmissions)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CreateResult> Add(Student c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<UpdateResult> Update(Student c)
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
