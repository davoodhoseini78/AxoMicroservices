namespace AxoMicroservices.Services.Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, List<string> Categories, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id); 

internal class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IDocumentSession _session;
    public CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"CreateProductCommand called with {command}");
        
        var product = new Product
        {
            Categories = command.Categories,
            Description = command.Description,
            Price = command.Price,
            ImageFile = command.ImageFile,
            Name = command.Name
        };

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
