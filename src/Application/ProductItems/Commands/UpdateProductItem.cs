using Kore.Application.Common.Interfaces;

namespace Kore.Application.ProductItems.Commands;

public record UpdateProductItemCommand(int Code) : IRequest
{
    public string? Title { get; init; }

    public string? Description { get; init; }
}

public class UpdateProductItemCommandHandler : IRequestHandler<UpdateProductItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.ProductCategories
        //    .FindAsync(new object[] { request.Code }, cancellationToken);
        var entity = await _context.ProductItems
            .FirstAsync(x => x.Code == request.Code, cancellationToken);

        Guard.Against.NotFound(request.Code, entity);

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
