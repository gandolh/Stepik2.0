using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services
{
    public class TeacherService : BaseCrudService<Teacher, TeacherDto>
    {
        public TeacherService(TeacherRepository repository) : base(repository, new TeacherMapper())
        {
        }
    }
}
