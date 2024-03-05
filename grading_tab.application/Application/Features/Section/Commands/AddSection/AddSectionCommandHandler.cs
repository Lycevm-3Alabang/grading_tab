using System.Text.Json;
using grading_tab.domain.AggregateModels.SectionAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace grading_tab.application.Application.Features.Section.Commands.AddSection;

public class AddSectionCommandHandler(ISectionRepository repository, ILogger<AddSectionCommandHandler> logger)
    : IRequestHandler<AddSectionCommand, Guid?>
{
    public async Task<Guid?> Handle(AddSectionCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Starting {nameof(AddSectionCommandHandler)}.");
        logger.LogInformation($"Creating {nameof(Section)}. Request:{JsonSerializer.Serialize(request)}");
        var created = repository.Create(new domain.AggregateModels.SectionAggregate.Section(request.Name));
        
        logger.LogInformation($"Saving {nameof(domain.AggregateModels.SectionAggregate.Section)}. Request:{JsonSerializer.Serialize(request)}");
        await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return created.Id;
    }
}