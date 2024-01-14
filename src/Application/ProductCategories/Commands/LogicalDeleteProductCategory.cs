using Kore.Application.Common.Interfaces;
using static Kore.Domain.Events.ProductCategoryEvents;

namespace Kore.Application.ProductCategories.Commands;

public record LogicalDeleteProductCategoryCommand(int Code) : IRequest
{
}

public class LogicalDeleteProductCategoryCommandHandler : IRequestHandler<LogicalDeleteProductCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public LogicalDeleteProductCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(LogicalDeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.ProductCategories
        //    .FindAsync(new object[] { request.Code }, cancellationToken);
        var entity = await _context.ProductCategories
            .FirstAsync(x => x.Code == request.Code, cancellationToken);

        Guard.Against.NotFound(request.Code, entity);

        entity.Deleted = true;

        entity.AddDomainEvent(new ProductCategoryLogicalDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
