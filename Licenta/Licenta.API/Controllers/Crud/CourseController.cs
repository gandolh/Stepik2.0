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
    public class CourseController : BaseCrudController<Course, CourseDto, FullCourseDto>
    {
        public CourseController(CourseService service) : base(service)
        {
        }

        [SwaggerOperation(Summary = "Get all courses", Description = "")]
        public override async Task<IEnumerable<CourseDto>> GetAll()
        {
            return await base.GetAll();
        }
        [SwaggerOperation(Summary = "Get course by Id", Description = "")]
        public override async Task<ActionResult<CourseDto>> GetOne(int id)
        {
            return await base.GetOne(id);
        }
        [SwaggerOperation(Summary = "Get full course all", Description = "")]
        public override async Task<IEnumerable<FullCourseDto>> GetFullAll()
        {
            return await base.GetFullAll();
        }
        [SwaggerOperation(Summary = "Get full course by Id", Description = "")]
        public override async Task<ActionResult<FullCourseDto>> GetFullOne(int id)
        {
            return await base.GetFullOne(id);
        }
        [SwaggerOperation(Summary = "Update course", Description = "")]
        public override async Task<UpdateResult> Update(CourseDto c)
        {
            return await base.Update(c);
        }
        [SwaggerOperation(Summary = "Delete course", Description = "")]
        public override async Task<DeleteResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
