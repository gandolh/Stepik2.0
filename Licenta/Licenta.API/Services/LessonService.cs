
using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class LessonService : BaseCrudService<Lesson, LessonDto>
    {
        private readonly FullLessonMapper _fullMapper;

        public LessonService(LessonRepository repository) : base(repository, new LessonMapper())
        {
            _fullMapper = new FullLessonMapper();
        }



        internal async Task<IEnumerable<LessonDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<FullLessonDto?> GetOne(int lessonId)
        {
            Lesson? lesson = await ((LessonRepository)_repository).GetJoinedLesson(lessonId);
            if (lesson == null)
                return null;
            var dto = _fullMapper.Map(lesson);
            return dto;
        }
    }
}
