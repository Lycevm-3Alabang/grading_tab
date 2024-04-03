using MediatR;

namespace grading_tab.application.Application.Features.SubjectLoading.Commands.AddSubjectLoad;

public class AddSubjectLoadCommand(Guid facultyId, Guid sectionId, int subjectId) : IRequest<Guid>
{
    public Guid FacultyId { get; } = facultyId;
    public Guid SectionId { get; } = sectionId;
    public int SubjectId { get; } = subjectId;
}