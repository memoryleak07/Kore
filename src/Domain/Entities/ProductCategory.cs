namespace Kore.Domain.Entities;

public class ProductCategory : BaseAuditableEntity
{
    public int Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public IList<ProductItem> ProductItems { get; private set; } = new List<ProductItem>();


}
