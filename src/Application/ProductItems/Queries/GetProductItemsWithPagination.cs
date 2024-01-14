using Kore.Application.Common.Interfaces;
using Kore.Application.Common.Models;
using Kore.Application.Common.Models.Mappings;
using Kore.Application.ProductItems.DTOs;

namespace Kore.Application.ProductItems.Queries;

public record GetProductItemsWithPaginationQuery : IRequest<PaginatedList<ProductItemDTO>>
{
    //public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductItemsWithPaginationQueryHandler : IRequestHandler<GetProductItemsWithPaginationQuery, PaginatedList<ProductItemDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductItemDTO>> Handle(GetProductItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProductItems
            .Where(x => x.Deleted == false)
            .OrderBy(x => x.LastModified)
            .ProjectTo<ProductItemDTO>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
