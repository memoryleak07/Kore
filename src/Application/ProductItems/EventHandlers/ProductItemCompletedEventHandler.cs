using Microsoft.Extensions.Logging;
using static Kore.Domain.Events.ProductItemEvents;

namespace Kore.Application.ProductItems.EventHandlers;

public class ProductCategoryCompletedEventHandler : INotificationHandler<ProductItemCompletedEvent>
{
    private readonly ILogger<ProductCategoryCompletedEventHandler> _logger;

    public ProductCategoryCompletedEventHandler(ILogger<ProductCategoryCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
