using AxoMicroservices.BuildingBlocks.CQRS;
using AxoMicroservices.Services.Catalog.API.Models;

namespace AxoMicroservices.Services.Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, List<string> Categories, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id); 

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Categories = command.Categories,
            Description = command.Description,
            Price = command.Price,
            ImageFile = command.Description,
            Name = command.Name
        };

        return new CreateProductResult(Guid.NewGuid());
    }
}