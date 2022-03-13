using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Persistence.Repositories
{
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private DevJobsContext _context;
        public JobVacancyRepository(DevJobsContext context)
        {
            _context = context;
        }
        public void Add(JobVacancy jobVacancy)
        {
            _context.JobVacancies.Add(jobVacancy);
            _context.SaveChanges();
        }

        public void AddApplication(JobApplication jobApplication)
        {
            _context.JobApplications.Add(jobApplication);
            _context.SaveChanges();
        }

        public List<JobVacancy> GetAll()
        {
            return _context.JobVacancies.ToList();
        }

        public JobVacancy GetById(int id)
        {
            var vacancy = _context
            .JobVacancies
            .Include(x => x.Applications)
            .SingleOrDefault(x => x.Id == id);

            return vacancy;
        }

        public void Update(JobVacancy jobVacancy)
        {
            _context.JobVacancies.Update(jobVacancy);
            _context.SaveChanges();
        }
    }
}