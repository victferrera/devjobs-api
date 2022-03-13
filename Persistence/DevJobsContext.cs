using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext : DbContext
    {
        public DevJobsContext(DbContextOptions<DevJobsContext> options) : base(options)
        {
            
        }
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JobVacancy>(e => {
                e.HasKey(x => x.Id);
                e.HasMany(x => x.Applications)
                    .WithOne()
                    .HasForeignKey(x => x.IdJobVacancy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JobApplication>(e => {
                e.HasKey(x => x.Id);
            });
        }
    }
}