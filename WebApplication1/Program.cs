
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.infrastructure.Repositories;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new ArgumentNullException(nameof(builder.Configuration));

// Add services to the container.
builder.Services
    .AddCustomDbContext(connectionString!)
    .AddCustomSwagger()
    .AddMediatorBundles()
    .AddEndpointsApiExplorer()
    .AddControllers();

builder.Services.AddScoped(typeof(ISectionRepository), typeof(SectionRepository));
    
var app = builder.Build();
var swaggerUrl = "/swagger/V1/swagger.json";
var swaggerName = "Lycevm Alabang - Grading API";
app.UseSwagger()
    .UseSwaggerUI(options => { options.SwaggerEndpoint(swaggerUrl, swaggerName); })
    .UseHttpsRedirection()
    .UseRouting()
    .UseAuthorization();

app.MapControllers();
app.Run();