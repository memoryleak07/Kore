using Kore.Application.Common.Interfaces;
using Kore.Domain.Entities;
using static Kore.Domain.Events.ProductCategoryEvents;

namespace Kore.Application.ProductCategories.Commands;

public record CreateProductCategoryCommand : IRequest<int>
{
    //public int ListId { get; init; }
    public int Code { get; set; }
    public string? Title { get; init; }
    public string? Description { get; init; }
}

public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductCategory
        {
            //ListId = request.ListId,
            Code = request.Code,
            Title = request.Title,
            Description = request.Description,
            //Done = false
        };

        entity.AddDomainEvent(new ProductCategoryCreatedEvent(entity));

        _context.ProductCategories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Code;
    }
}
