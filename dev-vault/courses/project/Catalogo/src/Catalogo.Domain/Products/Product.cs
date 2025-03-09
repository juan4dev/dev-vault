using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products.Events;

namespace Catalogo.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public string Description { get; set; }

    public Guid CategoryId { get; set; }

    public string Code { get; set; }

    private Product(
        Guid id,
        string name,
        decimal price,
        string? imageUrl,
        string description,
        Guid categoryId,
        string code

        ) : base(id)
    {
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        Description = description;
        CategoryId = categoryId;
        CategoryId = categoryId;
        Code = code;
    }

    public static Product Create(
        string name,
        decimal price,
        string? imageUrl,
        string description,
        Guid categoryId,
        string? code
        )
    {
        var guid = Guid.CreateVersion7();
        if(string.IsNullOrWhiteSpace(code))
        {
            code = $"{name[..Math.Min(name.Length, 5)].ToUpper()}-{guid.ToString("N")[..8]}";
        }

        var product = new Product(guid, name, price, imageUrl, description, categoryId, code);
        var productCreatedDomainEvent = new ProductCreatedDomainEvent(guid);
        product.RaiseDomainEvent(productCreatedDomainEvent);
        return product;
    }
}