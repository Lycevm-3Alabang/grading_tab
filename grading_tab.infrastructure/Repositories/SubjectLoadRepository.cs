using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class SubjectLoadRepository(GradingTabContext dbContext) : ISubjectLoadRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly GradingTabContext _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));

        public SubjectLoad Create(SubjectLoad subjectLoad)
        {
            return _dbContext.SubjectLoads.Add(subjectLoad).Entity;
        }

        public async Task<IEnumerable<SubjectLoad>> GetAllAsync()
        {
            var subjectLoads = await _dbContext.SubjectLoads
                .Include(x => x.Subject)
                .Include(x => x.Meetings).ThenInclude(x => x.Type)
                .Include(x => x.Faculty)
                .Include(x => x.Section)
                .ToListAsync();

            return subjectLoads;
        }

        public async Task<MeetingType?> GetMeetingTypeByIdAsync(int id)
        {
            return await _dbContext.MeetingTypes.AsNoTracking().SingleOrDefaultAsync(x => x!.Id == id);
        }

        public async Task<SubjectLoad?> GetByIdAsync(Guid id)
        {
            var subjectLoad = await _dbContext.SubjectLoads
                .Include(x => x.Subject)
                .Include(x => x.Meetings).ThenInclude(x => x.Type)
                .Include(x => x.Faculty)
                .Include(x => x.Section)
                .FirstOrDefaultAsync(x => x.Id == id);

            return subjectLoad;
        }

        public SubjectLoad Update(SubjectLoad subjectLoad)
        {
            return _dbContext.SubjectLoads.Update(subjectLoad).Entity;
        }
    }
}
