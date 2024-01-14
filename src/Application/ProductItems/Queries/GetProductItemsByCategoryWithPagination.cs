using Kore.Application.Common.Interfaces;
using Kore.Application.Common.Models;
using Kore.Application.Common.Models.Mappings;
using Kore.Application.ProductItems.DTOs;

namespace Kore.Application.ProductItems.Queries;

public record GetProductItemsByCategoryWithPaginationQuery(int CategoryCode) : IRequest<PaginatedList<ProductItemDTO>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductItemsByCategoryWithPaginationQueryHandler : IRequestHandler<GetProductItemsByCategoryWithPaginationQuery, PaginatedList<ProductItemDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductItemsByCategoryWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductItemDTO>> Handle(GetProductItemsByCategoryWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProductItems
            .Where(x => x.Deleted == false && x.CategoryCode == request.CategoryCode)
            .OrderBy(x => x.LastModified)
            .ProjectTo<ProductItemDTO>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
