using DevJobs.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacancyController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(UpdateJobVacancyInputModel model)
        {
            return NoContent();
        }

    }
}