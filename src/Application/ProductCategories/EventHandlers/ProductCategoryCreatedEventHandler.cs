using Microsoft.Extensions.Logging;
using static Kore.Domain.Events.ProductCategoryEvents;

namespace Kore.Application.ProductCategories.EventHandlers;

public class ProductCategoryCreatedEventHandler : INotificationHandler<ProductCategoryCreatedEvent>
{
    private readonly ILogger<ProductCategoryCreatedEventHandler> _logger;

    public ProductCategoryCreatedEventHandler(ILogger<ProductCategoryCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
