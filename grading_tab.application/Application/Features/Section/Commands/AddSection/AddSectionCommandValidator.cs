using FluentValidation;

namespace grading_tab.application.Application.Features.Section.Commands.AddSection;

public class AddSectionCommandValidator : AbstractValidator<AddSectionCommand>
{
    public AddSectionCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}