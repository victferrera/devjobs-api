using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacancyController : ControllerBase
    {
        DevJobsContext _context;
        public JobVacancyController(DevJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _context.JobVacancies;
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _context
            .JobVacancies
            .SingleOrDefault(x => x.Id == id);

            if(jobVacancy == null)
                return NotFound();
            else
                return Ok(jobVacancy);
        }

        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            _context.JobVacancies.Add(jobVacancy);

            return CreatedAtAction("GetById", new {id = jobVacancy.Id}, jobVacancy);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var JobVacancy = _context
            .JobVacancies
            .SingleOrDefault(x => x.Id == id);

            if(JobVacancy == null)
                return NotFound();
            else
                JobVacancy.Update(model.Title, model.Description);
                
            return NoContent();
        }

    }
}