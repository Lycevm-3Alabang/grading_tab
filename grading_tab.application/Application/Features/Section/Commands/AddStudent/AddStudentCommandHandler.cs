using System.Text.Json;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace grading_tab.application.Application.Features.Section.Commands.AddStudent;

public class AddStudentCommandHandler(ISectionRepository repository, ILogger<AddStudentCommandHandler> logger) : IRequestHandler<AddStudentCommand, Guid?>
{
    
    public async Task<Guid?> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Starting {nameof(AddStudentCommandHandler)}.");
        logger.LogInformation($"Creating {nameof(Section)}. Request:{JsonSerializer.Serialize(request)}");
        var section = await repository.GetByIdAsync(request.SectionId!.Value);

        if (section == null) throw new SectionNotFoundException();
        
        var student = new Student(request.Number, request.Course,
            new Person(request.FirstName, request.LastName, request.Middlename, request.NameSuffix));

        section.AddStudent(student);

        await repository.UnitOfWork.SaveChangesAsync(default);
        
        logger.LogInformation($"Saving {nameof(domain.AggregateModels.SectionAggregate.Section)}. Request:{JsonSerializer.Serialize(request)}");
        await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}