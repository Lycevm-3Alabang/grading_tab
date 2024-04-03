using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using MediatR;

namespace grading_tab.application.Application.Features.SubjectLoading.Commands.AddSubjectLoad;

public class AddSubjectLoadCommandHandler(ISubjectLoadRepository subjectLoadRepository)
    : IRequestHandler<AddSubjectLoadCommand, Guid>
{
    public async Task<Guid> Handle(AddSubjectLoadCommand request, CancellationToken cancellationToken)
    {
        var created = subjectLoadRepository.Create(new SubjectLoad(request.FacultyId, request.SectionId, request.SubjectId));
        await subjectLoadRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return created.Id;
    }
}