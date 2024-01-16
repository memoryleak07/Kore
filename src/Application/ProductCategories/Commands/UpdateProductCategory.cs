using Kore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kore.Application.ProductCategories.Commands;

public record UpdateProductCategoryCommand(int Code) : IRequest
{
    public string? Title { get; init; }
    public string? Description { get; init; }
}

public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.ProductCategories
        //    .FindAsync(new object[] { request.Code }, cancellationToken);
        var entity = await _context.ProductCategories
            .FirstAsync(x => x.Code == request.Code, cancellationToken);

        Guard.Against.NotFound(request.Code, entity);

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
