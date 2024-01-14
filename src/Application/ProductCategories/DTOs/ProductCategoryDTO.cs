using Kore.Domain.Entities;

namespace Kore.Application.ProductCategories.DTOs;

public class ProductCategoryDTO
{
    public string? Code { get; set; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductCategoryDTO, ProductCategory>()
                .ReverseMap();
                //.ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
        }
    }
}
