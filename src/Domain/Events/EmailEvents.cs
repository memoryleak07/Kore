namespace Kore.Domain.Events;

public class EmailEvents
{
    public class EmailCreatedEvent : BaseEvent
    {
        public EmailCreatedEvent(EmailMessage item)
        {
            Item = item;
        }
        public EmailMessage Item { get; }
    }
}
