
using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder.Interfaces;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Licenta.API.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly CourseMapper _courseMapper;
        private readonly FullCourseMapper _fullCourseMapper;
        private readonly TeacherMapper _teacherMapper;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _courseMapper = new CourseMapper();
            _fullCourseMapper = new FullCourseMapper();
            _teacherMapper = new TeacherMapper();

        }

        internal async Task<List<CourseDto>> GetAll(bool includeStudents, bool includeTeachers)
        {
            var courses = await _courseRepository.GetDetailedAsync(includeStudents, includeTeachers);
            var dtos = _courseMapper.Map(courses);
            return dtos;
        }

        internal async Task<FullCourseDto?> GetOne(int courseId)
        {
            Course? course =  await _courseRepository.GetJoinedCourse(courseId);
            if (course == null)
                return null;
            var dto = _fullCourseMapper.Map(course);
            return dto;
        }
    }
}
