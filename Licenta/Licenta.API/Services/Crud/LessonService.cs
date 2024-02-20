using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Licenta.API.Services.Crud
{
    public class LessonService : BaseCrudService<Lesson, LessonDto, FullLessonDto>
    {

        public LessonService(LessonRepository repository) : base(repository, new LessonMapper(), new FullLessonMapper())
        {
        }

        internal override async Task<IEnumerable<FullLessonDto>> GetFullAll()
        {
            return _fullMapper.Map(await _repository.GetAllAsync());
        }

        internal override async Task<FullLessonDto?> GetFullOne(int id)
        {
            var lesson = await ((LessonRepository)_repository).GetFullOne(id);
            if (lesson == null)
                return null;
            return _fullMapper.Map(lesson);
        }
    }
}
