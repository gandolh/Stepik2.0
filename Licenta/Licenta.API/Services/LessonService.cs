
using Licenta.API.Mappers;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class LessonService
    {
        private readonly LessonRepository _lessonRepository;
        private readonly FullLessonMapper _fullLessonMapper;

        public LessonService(LessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
            _fullLessonMapper = new FullLessonMapper();
        }
        internal async Task<FullLessonDto?> GetOne(int lessonId)
        {
            Lesson? lesson = await _lessonRepository.GetJoinedLesson(lessonId);
            if (lesson == null)
                return null;
            var dto = _fullLessonMapper.Map(lesson);
            return dto;
        }
    }
}
