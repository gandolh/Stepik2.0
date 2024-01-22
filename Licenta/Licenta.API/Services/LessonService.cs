
using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class LessonService
    {
        private readonly LessonRepository _repository;
        private readonly FullLessonMapper _fullLessonMapper;
        private readonly LessonMapper _lessonMapper;

        public LessonService(LessonRepository lessonRepository)
        {
            _repository = lessonRepository;
            _fullLessonMapper = new FullLessonMapper();
            _lessonMapper = new LessonMapper(); 
        }

        internal async Task<IEnumerable<LessonDto>> GetAll()
        {
            return _lessonMapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<FullLessonDto?> GetOne(int lessonId)
        {
            Lesson? lesson = await _repository.GetJoinedLesson(lessonId);
            if (lesson == null)
                return null;
            var dto = _fullLessonMapper.Map(lesson);
            return dto;
        }
    }
}
