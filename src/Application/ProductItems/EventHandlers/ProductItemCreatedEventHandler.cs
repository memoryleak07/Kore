using Microsoft.Extensions.Logging;
using static Kore.Domain.Events.ProductItemEvents;

namespace Kore.Application.ProductItems.EventHandlers;

public class ProductCategoryCreatedEventHandler : INotificationHandler<ProductItemCreatedEvent>
{
    private readonly ILogger<ProductCategoryCreatedEventHandler> _logger;

    public ProductCategoryCreatedEventHandler(ILogger<ProductCategoryCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
