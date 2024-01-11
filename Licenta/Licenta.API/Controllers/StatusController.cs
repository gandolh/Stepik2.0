using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Licenta.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Status of the API",
        Description = "Returns the status of the API. If this doesn't respond the API is down.")]
        public Task<HttpStatusCode> GetStatus()
        {
            return Task.FromResult(HttpStatusCode.OK);
        }
    }
}
