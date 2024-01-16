using Kore.Application.Common.Interfaces;
using Kore.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using static Kore.Domain.Events.EmailEvents;

namespace Kore.Application.Emails.Commands;

public record CreateSmtpEmailSendCommand : IRequest
{
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }

}

public class CreateSmtpEmailCommandHandler : IRequestHandler<CreateSmtpEmailSendCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateSmtpEmailCommandHandler> _logger;

    public CreateSmtpEmailCommandHandler(IApplicationDbContext context, ILogger<CreateSmtpEmailCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Handle(CreateSmtpEmailSendCommand request, CancellationToken cancellationToken)
    {
        SmtpClient emailClient = new("localhost");
        MailMessage message = new()
        {
            From = new MailAddress(request.From),
            Subject = request.Subject,
            Body = request.Body,
        };
        message.To.Add(new MailAddress(request.To));

        EmailMessage emailEvent = new();
        emailEvent.AddDomainEvent(new EmailCreatedEvent(emailEvent));

        await emailClient.SendMailAsync(message, cancellationToken);
    }

    //public Task SendFakeEmailAsync(string to, string from, string subject, string body)
    //{
    //    _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
    //    return Task.CompletedTask;
    //}
}

