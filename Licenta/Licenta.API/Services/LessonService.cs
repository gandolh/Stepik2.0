
using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class LessonService
    {
        private readonly LessonRepository _repository;
        private readonly FullLessonMapper _fullMapper;
        private readonly LessonMapper _mapper;

        public LessonService(LessonRepository lessonRepository)
        {
            _repository = lessonRepository;
            _fullMapper = new FullLessonMapper();
            _mapper = new LessonMapper(); 
        }



        internal async Task<IEnumerable<LessonDto>> GetAll()
        {
            return _mapper.Map(await _repository.GetAllAsync());
        }

        internal async Task<FullLessonDto?> GetOne(int lessonId)
        {
            Lesson? lesson = await _repository.GetJoinedLesson(lessonId);
            if (lesson == null)
                return null;
            var dto = _fullMapper.Map(lesson);
            return dto;
        }

        internal async Task<UpdateResult> Update(LessonDto c)
        {
            await _repository.UpdateAsync(_mapper.Map(c));
            return new(typeof(LessonDto), c.Id);
        }

        internal async Task<DeleteResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return new(typeof(LessonDto), id);
        }
    }
}
