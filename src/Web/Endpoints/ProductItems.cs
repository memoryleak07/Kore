using Kore.Application.Common.Models;
using Kore.Application.ProductItems.Commands;
using Kore.Application.ProductItems.DTOs;
using Kore.Application.ProductItems.Queries;

namespace Kore.Web.Endpoints;

public class ProductItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetProductItemsWithPagination)
            .MapGet(GetProductItemsByCategoryWithPagination, "ByCategory/{categorycode}")
            .MapPost(CreateProductItem)
            .MapPut(UpdateProductItem, "{code}")
            //.MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteProductItem, "Delete/{code}")
            .MapDelete(LogicalDeleteProductItem, "LogicalDelete/{code}");
    }

    public async Task<PaginatedList<ProductItemDTO>> GetProductItemsWithPagination(ISender sender, [AsParameters] GetProductItemsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<PaginatedList<ProductItemDTO>> GetProductItemsByCategoryWithPagination(ISender sender, [AsParameters] GetProductItemsByCategoryWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateProductItem(ISender sender, CreateProductItemCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateProductItem(ISender sender, int code, UpdateProductItemCommand command)
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

    public async Task<IResult> DeleteProductItem(ISender sender, int code)
    {
        await sender.Send(new DeleteProductItemCommand(code));
        return Results.NoContent();
    }

    public async Task<IResult> LogicalDeleteProductItem(ISender sender, int code)
    {
        await sender.Send(new LogicalDeleteProductItemCommand(code));
        return Results.NoContent();
    }
}
