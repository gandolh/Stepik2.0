using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class LessonService : BaseCrudService<Lesson, LessonDto, FullLessonDto>
    {

        public LessonService(LessonRepository repository) : base(repository, new LessonMapper(), new FullLessonMapper())
        {
        }

    }
}
