using Licenta.API.Models;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers.Crud
{
    public interface IBaseCrudController<TDto, TFullDto>
        where TDto : IDtoWithId
        where TFullDto : IDtoWithId
    {
        Task<DeleteResult> Delete(int id);
        Task<IEnumerable<TDto>> GetAll();
        Task<IEnumerable<TFullDto>> GetFullAll();
        Task<ActionResult<TFullDto>> GetFullOne(int id);
        Task<ActionResult<TDto>> GetOne(int id);
        Task<UpdateResult> Update(TDto c);
    }
}