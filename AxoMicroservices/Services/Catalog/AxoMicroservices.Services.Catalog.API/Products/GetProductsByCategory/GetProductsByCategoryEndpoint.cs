﻿using System.Net;

namespace AxoMicroservices.Services.Catalog.API.Products.GetProductsByCategory;

//public record GetProductsByCategoryRequest(string Category);
public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));
            var response = result.Adapt<GetProductsByCategoryResponse>();
            return Results.Ok(response);
        })
            .WithName("GetProductsByCategory")
            .Produces<GetProductsByCategoryResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetProductsByCategory summary")
            .WithDescription("GetProductsByCategory description");
    }
}