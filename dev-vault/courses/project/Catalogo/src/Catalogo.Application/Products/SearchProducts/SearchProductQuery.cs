using Catalogo.Application.Dtos;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

public class SearchProductQuery : IRequest<ProductDto>
{
    public required string Code { get; set; }
}