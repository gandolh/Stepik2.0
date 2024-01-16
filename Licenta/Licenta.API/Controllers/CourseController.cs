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
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses",
        Description = "Get all courses. The response could include list of participating students" +
            "or teachers")]
        public async Task<IEnumerable<CourseDto>> GetAll(bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses of a teacher",
        Description = "Get all courses of a teacher. The response could include list of participating students" +
            "and all the teachers that teaches that course")]
        public async Task<IEnumerable<CourseDto>> GetAllByTeacher(int teacherId, bool includeStudents, bool includeTeachers)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses of a student",
       Description = "Get all courses of a teacher. The response could include list of participating students" +
           "and all the teachers that teaches that course")]
        public async Task<IEnumerable<CourseDto>> GetAllByStudent(int studentId, bool includeStudents, bool includeTeachers)
        {
            // temporary for showcase. TODO: implement filter
            return await _courseService.GetAll(includeStudents, includeTeachers);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get one course by id",
        Description = "The response could include list of participating students" +
            "and teachers")]
        public async Task<ActionResult<FullCourseDto>> GetOne(int courseId)
        {
            var res = await _courseService.GetOne(courseId);
            if(res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new course", Description = "")]
        public async Task<CreateResult> Add(CourseDto c)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update course", Description = "")]
        public async Task<UpdateResult> Update(CourseDto c)
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
