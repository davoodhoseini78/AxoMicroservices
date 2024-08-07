namespace AxoMicroservices.Services.Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
public record GetProductsByCategoryResult(IEnumerable<Product> Products);

public class GetProductsByCategoryQueryHandler
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    private readonly ILogger<GetProductsByCategoryQueryHandler> _logger;
    private readonly IDocumentSession _session;

    public GetProductsByCategoryQueryHandler(ILogger<GetProductsByCategoryQueryHandler> logger, IDocumentSession session)
    {
        _logger = logger;
        _session = session;
    }
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetProductsByCategoryQuery called with {query}");
        var products = await _session.Query<Product>().Where(c=>c.Categories.Contains(query.Category)).ToListAsync(cancellationToken);
        return new GetProductsByCategoryResult(products);
    }
}