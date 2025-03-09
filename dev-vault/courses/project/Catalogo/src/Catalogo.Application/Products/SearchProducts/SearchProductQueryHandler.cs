using Catalogo.Application.Dtos;
using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

internal sealed class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, ProductDto>
{
    private readonly IProductRepository _repository;

    public SearchProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> Handle(SearchProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByCode(request.Code, cancellationToken) ?? throw new KeyNotFoundException();

        return product.ToDto();
    }
}