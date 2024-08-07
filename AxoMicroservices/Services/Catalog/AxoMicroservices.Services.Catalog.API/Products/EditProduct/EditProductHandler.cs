namespace AxoMicroservices.Services.Catalog.API.Products.EditProduct;

public record EditProductCommand(Guid Id, string Name, string Description, List<string> Categories, string ImageFile, decimal Price) : ICommand<EditProductResult>;

public record EditProductResult(bool IsSuccess);

public class EditProductCommandHandler : ICommandHandler<EditProductCommand, EditProductResult>
{
    private readonly ILogger<EditProductCommandHandler> _logger;
    private readonly IDocumentSession _documentSession;
    public EditProductCommandHandler(IDocumentSession documentSession, ILogger<EditProductCommandHandler> logger)
    {
        _documentSession = documentSession;
        _logger = logger;
    }


    public async Task<EditProductResult> Handle(EditProductCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"EditProductCommand called with {command}");

        var product = await _documentSession.LoadAsync<Product>(command.Id, cancellationToken);
        if (product == null)
            throw new ProductNotFoundException();

        product.Name = command.Name;
        product.Description = command.Description;
        product.Price = command.Price;
        product.Categories = command.Categories;
        product.ImageFile = command.ImageFile;

        _documentSession.Update(product);
        await _documentSession.SaveChangesAsync(cancellationToken);

        return new EditProductResult(true);
    }
}