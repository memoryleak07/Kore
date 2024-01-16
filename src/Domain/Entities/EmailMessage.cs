using System.Net.Mail;

namespace Kore.Domain.Entities;

public class EmailMessage : BaseAuditableEntity
{
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
}
