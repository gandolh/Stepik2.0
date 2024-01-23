
using Licenta.API.Mappers;
using Licenta.API.Models;
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
        private readonly CourseRepository _repository;
        private readonly CourseMapper _mapper;
        private readonly FullCourseMapper _fullMapper;
        private readonly TeacherMapper _teacherMapper;

        public CourseService(CourseRepository courseRepository)
        {
            _repository = courseRepository;
            _mapper = new CourseMapper();
            _fullMapper = new FullCourseMapper();
            _teacherMapper = new TeacherMapper();

        }

        internal async Task<List<CourseDto>> GetAll(bool includeStudents, bool includeTeachers)
        {
            var courses = await _repository.GetDetailedAsync(includeStudents, includeTeachers);
            var dtos = _mapper.Map(courses);
            return dtos;
        }

        internal async Task<FullCourseDto?> GetOne(int courseId)
        {
            Course? course =  await _repository.GetJoinedCourse(courseId);
            if (course == null)
                return null;
            var dto = _fullMapper.Map(course);
            return dto;
        }

        internal async Task<UpdateResult> Update(CourseDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(CourseDto), c.Id);
        }
    }
}
