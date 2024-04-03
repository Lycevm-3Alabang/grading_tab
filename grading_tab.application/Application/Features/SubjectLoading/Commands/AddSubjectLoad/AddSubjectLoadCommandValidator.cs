using FluentValidation;

namespace grading_tab.application.Application.Features.SubjectLoading.Commands.AddSubjectLoad;

public class AddSubjectLoadCommandValidator : AbstractValidator<AddSubjectLoadCommand>
{
    public AddSubjectLoadCommandValidator()
    {
        RuleFor(x => x.FacultyId).NotEmpty();
        RuleFor(x => x.SectionId).NotEmpty();
        RuleFor(x => x.SubjectId).NotEmpty();
    }
}