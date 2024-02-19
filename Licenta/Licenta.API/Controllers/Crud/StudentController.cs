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
    public class StudentController : BaseCrudController<Student, StudentDto, StudentDto>
    {
        public StudentController(StudentService service) : base(service)
        {
        }


        [SwaggerOperation(Summary = "Get all students", Description = "")]
        public override async Task<IEnumerable<StudentDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get student by Id", Description = "")]
        public override async Task<ActionResult<StudentDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full student all", Description = "")]
        public override async Task<IEnumerable<StudentDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full student by Id", Description = "")]
        public override async Task<ActionResult<StudentDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update student", Description = "")]
        public override async Task<UpdateResult> Update(StudentDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Delete student", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
