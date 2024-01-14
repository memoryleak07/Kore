using Kore.Application.Common.Models;
using Kore.Application.ProductCategories.Commands;
using Kore.Application.ProductCategories.DTOs;
using Kore.Application.ProductCategories.Queries;

namespace Kore.Web.Endpoints;

public class ProductCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetProductCategoriesWithPagination)
            .MapPost(CreateProductCategory)
            .MapPut(UpdateProductCategory, "{code}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteProductCategory, "Delete/{code}")
            .MapDelete(LogicalDeleteProductCategory, "LogicalDelete/{code}");
    }

    public async Task<PaginatedList<ProductCategoryDTO>> GetProductCategoriesWithPagination(ISender sender, [AsParameters] GetProductCategoriesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateProductCategory(ISender sender, CreateProductCategoryCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateProductCategory(ISender sender, int code, UpdateProductCategoryCommand command)
    {
        if (code != command.Code) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    //public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
    //{
    //    if (id != command.Id) return Results.BadRequest();
    //    await sender.Send(command);
    //    return Results.NoContent();
    //}

    public async Task<IResult> DeleteProductCategory(ISender sender, int code)
    {
        await sender.Send(new DeleteProductCategoryCommand(code));
        return Results.NoContent();
    }

    public async Task<IResult> LogicalDeleteProductCategory(ISender sender, int code)
    {
        await sender.Send(new LogicalDeleteProductCategoryCommand(code));
        return Results.NoContent();
    }
}
