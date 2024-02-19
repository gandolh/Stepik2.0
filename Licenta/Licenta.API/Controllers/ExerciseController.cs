﻿using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _service;

        public ExerciseController(ExerciseService exerciseService)
        {
            _service = exerciseService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all exercises", Description = "")]
        public async Task<IEnumerable<ExerciseDto>> GetAll()
        {
            return await _service.GetAll();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get exercise by id",
            Description = "The response could include submissions for that exercise.")]
        public async Task<ActionResult<ExerciseDto>> GetOne(int id)
        {
            var res = await _service.GetOne(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update exercise", Description = "")]
        public async Task<UpdateResult> Update(ExerciseDto c)
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
