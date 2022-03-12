using DevJob.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevJob.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            return NoContent();
        }
    }
}