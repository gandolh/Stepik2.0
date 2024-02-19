using Licenta.API.Models;
using Licenta.API.Services.Crud;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers.Crud
{
    public abstract class BaseCrudController<T, TDto, TFullDto>
        : ControllerBase
        where TDto : IDtoWithId where TFullDto : IDtoWithId
    {
        protected readonly BaseCrudService<T, TDto, TFullDto> _service;


        protected BaseCrudController(BaseCrudService<T, TDto, TFullDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        public virtual async Task<ActionResult<TDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TFullDto>> GetFullAll()
        {
            return await _service.GetFullAll();
        }

        [HttpGet]
        public virtual async Task<ActionResult<TFullDto>> GetFullOne(int id)
        {
            var res = await _service.GetFullOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }


        [HttpPut]
        public virtual async Task<UpdateResult> Update(TDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        public virtual async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }

    }
}
