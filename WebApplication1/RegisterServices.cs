using System.Reflection;
using FluentValidation;
using grading_tab.application.Application.Behaviors;
using grading_tab.application.Application.Features.Section.Commands.AddSection;
using grading_tab.infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebApplication1;

public static class RegisterServices
{
    internal static IServiceCollection AddCustomDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GradingTabContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseSqlServer(connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(GradingTabContext).Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                    });
            } //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
        );

        return services;
    }
    internal static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("V1", new OpenApiInfo
            {
                Version = "V1",
                Title = "WebAPI",
                Description = "Lycevm Alabang Grading API"
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Bearer Authentication with JWT Token",
                Type = SecuritySchemeType.Http
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        });

        return services;
    }
    
    internal static IServiceCollection AddMediatorBundles(this IServiceCollection services)
    {

        //register mediatr and pipelines
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(AddSectionCommand).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

        // Register command and query handlers
        services.AddScoped<IRequestHandler<AddSectionCommand, Guid?>, AddSectionCommandHandler>();

        // Register validators
        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(AddSectionCommandValidator)));
        return services;
    }
}