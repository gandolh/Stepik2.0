﻿using Licenta.API.Models;
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
        private readonly CourseService _service;

        public CourseController(CourseService courseService)
        {
            _service = courseService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses of a student",
       Description = "Get all courses of a teacher. The response could include list of participating students" +
           "and all the teachers that teaches that course")]
        public async Task<IEnumerable<CourseDto>> GetAllByStudent(int studentId, bool includeStudents, bool includeTeachers)
        {
            return await _service.GetAll(includeStudents, includeTeachers);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get one course by Id",
        Description = "The response could include list of participating students" +
            "and teachers")]
        public async Task<ActionResult<FullCourseDto>> GetOne(int courseId)
        {
            var res = await _service.GetFullOne(courseId);
            if(res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update course", Description = "")]
        public async Task<UpdateResult> Update(CourseDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "delete course", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
