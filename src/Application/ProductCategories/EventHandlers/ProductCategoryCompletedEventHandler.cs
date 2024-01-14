using Microsoft.Extensions.Logging;
using static Kore.Domain.Events.ProductCategoryEvents;

namespace Kore.Application.ProductCategories.EventHandlers;

public class ProductCategoryCompletedEventHandler : INotificationHandler<ProductCategoryCompletedEvent>
{
    private readonly ILogger<ProductCategoryCompletedEventHandler> _logger;

    public ProductCategoryCompletedEventHandler(ILogger<ProductCategoryCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCategoryCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
