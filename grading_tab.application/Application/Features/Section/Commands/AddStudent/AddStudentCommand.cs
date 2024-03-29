using System.Text.Json;
using FluentValidation;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace grading_tab.application.Application.Features.Section.Commands.AddStudent;

public class AddStudentCommand : IRequest<Guid?>
{
    public Guid? SectionId { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Middlename { get; init; }

    public string? NameSuffix { get; init; }

    public string? Number { get; init; }

    public string? Course { get; init; }
}

public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
    public AddStudentCommandValidator()
    {
        RuleFor(x => x.SectionId).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
    }
}

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