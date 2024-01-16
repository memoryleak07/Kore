using Kore.Domain.Entities;
using Kore.Domain.Enums;

namespace Kore.Application.ProductItems.DTOs;

public class ProductItemDTO
{
    public string? Code { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public PriorityLevel Priority { get; set; }

    public decimal Price { get; set; }

    public bool IsVegetarian { get; set; }

    public bool IsVegan { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductItemDTO, ProductItem>()
                .ForMember(d => d.Priority,opt => opt.MapFrom(s => (int)s.Priority))
                .ReverseMap();
                //.ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
        }
    }
}
