using Catalogo.Domain.Products;
using MediatR;

namespace Catalogo.Application.Products.SearchProducts;

public class SearchProductQuery : IRequest<Product>
{
    public required string Code { get; set; }
}