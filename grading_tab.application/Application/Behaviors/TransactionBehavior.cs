using grading_tab.application.Extensions;
using grading_tab.infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace grading_tab.application.Application.Behaviors
{
    public class TransactionBehaviour<TRequest, TResponse>(
        GradingTabContext dbContext,
        ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly GradingTabContext _dbContext = dbContext ?? throw new ArgumentException(nameof(GradingTabContext));

        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        //TODO: Not this time ->private readonly ICatalogIntegrationEventService _orderingIntegrationEventService;
        //TODO: Not this time ->ICatalogIntegrationEventService orderingIntegrationEventService,
        //TODO: Not this time ->_orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentException(nameof(orderingIntegrationEventService));

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var response = default(TResponse);
            var typeName = request.GetGenericTypeName();


            try
            {

            
                if (_dbContext.HasActiveTransaction) return await next();
            
                var strategy = _dbContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    await using var transaction = await _dbContext.BeginTransactionAsync();
                    using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
                    {
                        _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.TransactionId, typeName, request);

                        response = await next();

                        _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

                        await _dbContext.CommitTransactionAsync(transaction);
            
                        transactionId = transaction.TransactionId;
                    }
            
                    //TODO: Not this time -> await _orderingIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);
                });

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

                throw;
            }
        }
    }
}