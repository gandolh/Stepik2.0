using Licenta.API.Models;
using Licenta.API.Services;
using Licenta.Db.DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubmissionController : ControllerBase
    {
        private readonly SubmissionService _submissionService;

        public SubmissionController(SubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

    }
}
