using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    public abstract class BaseCrudController<T, TDto> : ControllerBase where TDto : IDtoWithId
    {
        protected readonly BaseCrudService<T, TDto> _service;


        protected BaseCrudController(BaseCrudService<T,TDto> service)
        {
            _service = service;
        }


        [HttpPut]
        [SwaggerOperation(Summary = "Update exercise", Description = "")]
        public async Task<UpdateResult> Update(TDto c)
        {
            return await _service.Update(c);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete exercise", Description = "")]
        public async Task<DeleteResult> Delete(int id)
        {
            return await _service.Delete(id);
        }

    }
}
