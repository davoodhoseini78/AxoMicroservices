using AxoMicroservices.Services.Catalog.API.Products.CreateProduct;

namespace AxoMicroservices.Services.Catalog.API.Products.EditProduct;

public record EditProductRequest(Guid Id, string Name, string Description, List<string> Categories, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record EditProductResponse(bool IsSuccess);

public class EditProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (EditProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<EditProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<EditProductResponse>();
                return Results.Ok(response);
            })
            .WithName("EditProduct")
            .Produces<EditProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("EditProduct summary")
            .WithDescription("EditProduct description");
    }
}