namespace Kore.Domain.Events;

public class ProductCategoryEvents
{
    // Complete
    public class ProductCategoryCompletedEvent : BaseEvent
    {
        public ProductCategoryCompletedEvent(ProductCategory item)
        {
            Item = item;
        }

        public ProductCategory Item { get; }
    }

    // Create
    public class ProductCategoryCreatedEvent : BaseEvent
    {
        public ProductCategoryCreatedEvent(ProductCategory item)
        {
            Item = item;
        }

        public ProductCategory Item { get; }
    }

    // Delete
    public class ProductCategoryDeletedEvent : BaseEvent
    {
        public ProductCategoryDeletedEvent(ProductCategory item)
        {
            Item = item;
        }

        public ProductCategory Item { get; }
    }

    // Logical Delete
    public class ProductCategoryLogicalDeletedEvent : BaseEvent
    {
        public ProductCategoryLogicalDeletedEvent(ProductCategory item)
        {
            Item = item;
        }

        public ProductCategory Item { get; }
    }
}
