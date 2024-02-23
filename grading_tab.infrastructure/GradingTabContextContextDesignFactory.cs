using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace grading_tab.infrastructure;

public class GradingTabContextContextDesignFactory : IDesignTimeDbContextFactory<GradingTabContext>
{
    public GradingTabContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GradingTabContext>()
            .UseSqlServer("Server=localhost;Database=E3_DB;User Id=sa;Password=someThingComplicated1234;TrustServerCertificate=True;MultiSubnetFailover=True;", 
                x => x.MigrationsAssembly(typeof(GradingTabContext).Assembly.FullName));

        return new GradingTabContext(optionsBuilder.Options);
    }
}