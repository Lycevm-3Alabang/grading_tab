using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.AssessmentResultAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure
{
    public class GradingTabContext : DbContext, IUnitOfWork
    {

        public GradingTabContext(DbContextOptions<GradingTabContext> options) : base(options)
        {
        }

        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<SubjectLoad> SubjectLoads { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<Term> Terms { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        
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
