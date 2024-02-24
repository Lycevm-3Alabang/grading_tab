using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace grading_tab.infrastructure
{
    public class GradingTabContext : DbContext, IUnitOfWork
    {

        public GradingTabContext(DbContextOptions<GradingTabContext> options) : base(options)
        {
        }

        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<SubjectLoad> SubjectLoads { get; set; }
        public DbSet<Person> People { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            _ = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GradingTabContext).Assembly);
        }
    }
}
