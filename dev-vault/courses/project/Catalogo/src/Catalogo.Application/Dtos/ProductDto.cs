using Catalogo.Domain.Products;

namespace Catalogo.Application.Dtos;

public static class ProductMapper
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto(
            product.Id,
            product.Code,
            product.Name,
            product.Description,
            product.Price,
            product.ImageUrl,
            product.CategoryId
        );
    }
}

public sealed record ProductDto(
    Guid Id,
    string Code,
    string Name,
    string Description,
    decimal Price,
    string ImageUrl,
    Guid CategoryId
);