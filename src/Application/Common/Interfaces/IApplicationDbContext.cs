using Kore.Domain.Entities;

namespace Kore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<ProductItem> ProductItems { get; }

    DbSet<ProductCategory> ProductCategories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
