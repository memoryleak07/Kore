using Microsoft.Extensions.Logging;
using static Kore.Domain.Events.EmailEvents;

namespace Kore.Application.Emails.EventHandlers;

public class EmailCreatedEventHandler : INotificationHandler<EmailCreatedEvent>
{
    private readonly ILogger<EmailCreatedEventHandler> _logger;

    public EmailCreatedEventHandler(ILogger<EmailCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EmailCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kore Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
