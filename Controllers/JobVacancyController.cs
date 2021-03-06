using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacancyController : ControllerBase
    {
        public IJobVacancyRepository _repository { get; set; }
        public JobVacancyController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);

            if(jobVacancy == null)
                return NotFound();
            else
                return Ok(jobVacancy);
        }

        /// <summary>
        /// Cadastrar uma vaga de emprego.
        /// </summary>
        /// <param name="model">Informações da vaga.</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso.</response>
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            Log.Information("POST JobVacancy chamado");
            
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            _repository.Add(jobVacancy);

            return CreatedAtAction("GetById", new {id = jobVacancy.Id}, jobVacancy);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var JobVacancy = _repository.GetById(id);

            if(JobVacancy == null)
                return NotFound();

            JobVacancy.Update(model.Title, model.Description);

            _repository.Update(JobVacancy);
                
            return NoContent();
        }

    }
}