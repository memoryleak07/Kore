using Kore.Application.Common.Interfaces;
using Kore.Application.Common.Models;
using Kore.Application.Common.Models.Mappings;
using Kore.Application.ProductCategories.DTOs;

namespace Kore.Application.ProductCategories.Queries;

public record GetProductCategoriesWithPaginationQuery : IRequest<PaginatedList<ProductCategoryDTO>>
{
    //public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductCategoriesWithPaginationHandler : IRequestHandler<GetProductCategoriesWithPaginationQuery, PaginatedList<ProductCategoryDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductCategoriesWithPaginationHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductCategoryDTO>> Handle(GetProductCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProductCategories
            .Where(x => x.Deleted == false)
            .OrderBy(x => x.LastModified)
            .ProjectTo<ProductCategoryDTO>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
