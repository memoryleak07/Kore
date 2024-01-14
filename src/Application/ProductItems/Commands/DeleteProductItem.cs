using Kore.Application.Common.Interfaces;
using static Kore.Domain.Events.ProductItemEvents;

namespace Kore.Application.ProductItems.Commands;

public record DeleteProductItemCommand(int Code) : IRequest;

public class DeleteProductItemCommandHandler : IRequestHandler<DeleteProductItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.ProductCategories
        //    .FindAsync(new object[] { request.Code }, cancellationToken);
        var entity = await _context.ProductItems
            .FirstAsync(x => x.Code == request.Code, cancellationToken);

        Guard.Against.NotFound(request.Code, entity);

        _context.ProductItems.Remove(entity);

        entity.AddDomainEvent(new ProductItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
