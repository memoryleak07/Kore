using Kore.Domain.Entities;

namespace Kore.Application.ProductItems.DTOs;

public class ProductItemDTO
{
    public string? Code { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductItemDTO, ProductItem>()
                .ReverseMap();
                //.ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
        }
    }
}
