using Kore.Application.Common.Interfaces;
using static Kore.Domain.Events.ProductCategoryEvents;

namespace Kore.Application.ProductCategories.Commands;

public record DeleteProductCategoryCommand(int Code) : IRequest;

public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.ProductCategories
        //    .FindAsync(new object[] { request.Code }, cancellationToken);
        var entity = await _context.ProductCategories
            .FirstAsync(x => x.Code == request.Code, cancellationToken);

        Guard.Against.NotFound(request.Code, entity);
        
        _context.ProductCategories.Remove(entity);

        entity.AddDomainEvent(new ProductCategoryDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
