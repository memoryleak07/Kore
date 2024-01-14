using Kore.Application.Common.Interfaces;
using static Kore.Domain.Events.ProductItemEvents;

namespace Kore.Application.ProductItems.Commands;

public record LogicalDeleteProductItemCommand(int Code) : IRequest
{
}

public class LogicalDeleteProductItemCommandHandler : IRequestHandler<LogicalDeleteProductItemCommand>
{
    private readonly IApplicationDbContext _context;

    public LogicalDeleteProductItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(LogicalDeleteProductItemCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.ProductCategories
        //    .FindAsync(new object[] { request.Code }, cancellationToken);
        var entity = await _context.ProductItems
            .FirstAsync(x => x.Code == request.Code, cancellationToken);

        Guard.Against.NotFound(request.Code, entity);

        entity.Deleted = true;

        entity.AddDomainEvent(new ProductItemLogicalDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
