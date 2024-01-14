namespace Kore.Domain.Events;

public class ProductItemEvents
{
    // Complete
    public class ProductItemCompletedEvent : BaseEvent
    {
        public ProductItemCompletedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }

    // Create
    public class ProductItemCreatedEvent : BaseEvent
    {
        public ProductItemCreatedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }

    // Delete
    public class ProductItemDeletedEvent : BaseEvent
    {
        public ProductItemDeletedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }

    // Logical Delete
    public class ProductItemLogicalDeletedEvent : BaseEvent
    {
        public ProductItemLogicalDeletedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }
}
