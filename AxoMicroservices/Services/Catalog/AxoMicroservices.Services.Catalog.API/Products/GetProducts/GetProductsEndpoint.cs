using AxoMicroservices.Services.Catalog.API.Products.CreateProduct;

namespace AxoMicroservices.Services.Catalog.API.Products.GetProducts;

public record GetProductsRequest();
public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender)=>
        {
            var result = await sender.Send(new GetProductsQuery());
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        })
            .WithName("Get Products")
            .Produces<CreateProductResponse>()
            .WithSummary("Get Products Summary")
            .WithDescription("Get Products Description");
    }
}