using FluentValidation;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using MediatR;

namespace grading_tab.application.Application.Features.SubjectLoading.Commands.AddMeeting;

public class AddMeetingCommand(Guid subjectLoadId, int typeId, int startTime, int endTime, DayOfWeek day) : IRequest<Guid>
{
    public Guid SubjectLoadId { get; } = subjectLoadId;
    public int TypeId { get; } = typeId;
    public int StartTime { get; } = startTime;
    public int EndTime { get; } = endTime;
    public DayOfWeek Day { get; } = day;
}

public class AddMeetingCommandValidator : AbstractValidator<AddMeetingCommand>
{
    public AddMeetingCommandValidator()
    {
        RuleFor(x => x.TypeId).NotEmpty();
        RuleFor(x => x.StartTime).GreaterThanOrEqualTo(0).LessThanOrEqualTo(23).NotEmpty();
        RuleFor(x => x.EndTime).GreaterThanOrEqualTo(0).LessThanOrEqualTo(23).NotEmpty();
        RuleFor(x => x.Day).NotEqual(DayOfWeek.Sunday).NotEmpty();
    }
}

public class AddMeetingCommandHandler(ISubjectLoadRepository subjectLoadRepository)
    : IRequestHandler<AddMeetingCommand, Guid>
{

    public async Task<Guid> Handle(AddMeetingCommand request, CancellationToken cancellationToken)
    {
        var subjectLoad = await subjectLoadRepository.GetByIdAsync(request.SubjectLoadId);

        return Guid.NewGuid();
    }
}