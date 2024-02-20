using Licenta.API.Mappers;
using Licenta.API.Models;
using Licenta.Db.DataModel;
using Licenta.Db.Repositories;
using Licenta.SDK.Models.Dtos;

namespace Licenta.API.Services.Crud
{
    public class TeacherService : BaseCrudService<Teacher, TeacherDto, TeacherDto>
    {
        public TeacherService(TeacherRepository repository) : base(repository, new TeacherMapper(), new TeacherMapper())
        {
        }

        internal override async Task<IEnumerable<TeacherDto>> GetFullAll()
        {
            return await base.GetAll();
        }

        internal override async Task<TeacherDto> GetFullOne(int id)
        {
            return await base.GetOne(id);
        }
    }
}
