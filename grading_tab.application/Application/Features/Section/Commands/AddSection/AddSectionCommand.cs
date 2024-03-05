using MediatR;

namespace grading_tab.application.Application.Features.Section.Commands.AddSection;

public class AddSectionCommand(string name) : IRequest<Guid?>
{
    public string Name { get; private set; } = name;
}