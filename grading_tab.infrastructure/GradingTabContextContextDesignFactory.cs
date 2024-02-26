using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;

namespace grading_tab.infrastructure;

public class GradingTabContextContextDesignFactory : IDesignTimeDbContextFactory<GradingTabContext>
{
    public GradingTabContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GradingTabContext>()
            .UseSqlServer("Server=localhost;Database=E3_DB;User Id=sa;Password=someThingComplicated1234;TrustServerCertificate=True;MultiSubnetFailover=True;", 
                x => x.MigrationsAssembly(Assembly.GetAssembly(typeof(GradingTabContext))?.GetName().Name));

        return new GradingTabContext(optionsBuilder.Options);
    }
}