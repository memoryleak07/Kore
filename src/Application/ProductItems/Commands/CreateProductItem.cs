using Kore.Application.Common.Interfaces;
using Kore.Domain.Entities;
using static Kore.Domain.Events.ProductItemEvents;

namespace Kore.Application.ProductItems.Commands;

public record CreateProductItemCommand : IRequest<int>
{
    public int Code { get; set; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public int CategoryId { get; init; }
}

public class CreateProductItemCommandHandler : IRequestHandler<CreateProductItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductItem
        {
            Code = request.Code,
            Title = request.Title,
            Description = request.Description,
            CategoryCode = request.CategoryId
        };

        entity.AddDomainEvent(new ProductItemCreatedEvent(entity));

        _context.ProductItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Code;
    }
}
