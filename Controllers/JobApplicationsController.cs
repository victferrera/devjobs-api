using DevJob.API.Models;
using DevJobs.API.Entities;
using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevJob.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private IJobVacancyRepository _repository;
        public JobApplicationsController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if(jobVacancy == null)
                return NotFound();

            var application = new JobApplication(
                model.ApplicantEmail,
                model.ApplicantName,
                id
            );

            _repository.AddApplication(application);
            
            return NoContent();
        }
    }
}