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
    public class TeacherController : BaseCrudController<Teacher, TeacherDto, TeacherDto>
    {

        public TeacherController(TeacherService service) : base(service) { }


        [SwaggerOperation(Summary = "Get all teachers", Description = "")]
        public override async Task<IEnumerable<TeacherDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get teacher by Id", Description = "")]
        public override async Task<ActionResult<TeacherDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full teacher all", Description = "")]
        public override async Task<IEnumerable<TeacherDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full teacher by Id", Description = "")]
        public override async Task<ActionResult<TeacherDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update teacher", Description = "")]
        public override async Task<UpdateResult> Update(TeacherDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Delete teacher", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
