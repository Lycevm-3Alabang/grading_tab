using MediatR;

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