using DevJob.API.Models;
using DevJobs.API.Entities;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJob.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private DevJobsContext _context;
        public JobApplicationsController(DevJobsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var jobVacancy = _context
            .JobVacancies
            .SingleOrDefault(x => x.Id == id);

            if(jobVacancy == null)
                return NotFound();

            var application = new JobApplication(
                model.ApplicantEmail,
                model.ApplicantName,
                id
            );

            jobVacancy.Applications.Add(application);
            
            return NoContent();
        }
    }
}