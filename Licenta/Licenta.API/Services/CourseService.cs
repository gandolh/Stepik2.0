
using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder.Interfaces;
using Licenta.SDK.Models.Dtos;
using System.Collections.Generic;

namespace Licenta.API.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly CourseMapper _mapper;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = new CourseMapper();

        }

        internal async Task<List<CourseDto>> GetAll(bool includeStudents, bool includeTeachers)
        {
            var courses = await _courseRepository.GetAllAsync();
            var dtos = _mapper.Map(courses);
            return dtos;
        }
    }
}
