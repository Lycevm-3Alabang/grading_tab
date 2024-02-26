using grading_tab.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace grading_tab.infrastructure_tests;

public static class FakeDbContext
{
    private static GradingTabContext? _sharedContext;

    public static async Task<GradingTabContext?> GetSharedDbContext()
    {
        if (_sharedContext != null) return _sharedContext;
        var dbContextOptions = new DbContextOptionsBuilder<GradingTabContext>()
            .UseInMemoryDatabase(databaseName: "in-memory")
            .Options;
        _sharedContext = new GradingTabContext(dbContextOptions);
        await _sharedContext.Database.EnsureDeletedAsync();
        await _sharedContext.Database.EnsureCreatedAsync();
        return _sharedContext;
    }
}