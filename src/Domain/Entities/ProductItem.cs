namespace Kore.Domain.Entities;

public class ProductItem : BaseAuditableEntity
{
    public int Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int CategoryCode { get; set; }

    public decimal Price { get; set; }

    public int Priority { get; set; }

    public bool IsAvailable { get; set; }

    public bool IsVegetarian { get; set; }

    public bool IsVegan { get; set; }

    // Navigation Property
    public virtual ProductCategory? CategoryNav { get; }

    //public PriorityLevel Priority { get; set; }

    //public DateTime? Reminder { get; set; }

    //private bool _done;
    //public bool Done
    //{
    //    get => _done;
    //    set
    //    {
    //        if (value && !_done)
    //        {
    //            AddDomainEvent(new ProductItemCreatedEvent(this));
    //        }

    //        _done = value;
    //    }
    //}

    //public TodoList List { get; set; } = null!;
}
