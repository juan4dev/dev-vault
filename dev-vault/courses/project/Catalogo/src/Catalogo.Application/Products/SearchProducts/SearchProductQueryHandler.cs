using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

internal sealed class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, Product>
{
    private readonly IProductRepository _repository;

    public SearchProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(SearchProductQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCode(request.Code, cancellationToken) ?? throw new KeyNotFoundException("Product not found");
    }
}