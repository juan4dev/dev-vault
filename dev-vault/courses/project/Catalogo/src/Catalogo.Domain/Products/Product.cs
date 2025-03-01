using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Products.Events;

namespace Catalogo.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public string Description { get; set; }

    private Product(
        Guid id,
        string name,
        decimal price,
        string imageUrl,
        string description
        ) : base(id)
    {
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        Description = description;
    }

    public static Product Create(
        string name,
        decimal price,
        string imageUrl,
        string description
        )
    {
        var guid = Guid.NewGuid();
        var product = new Product(guid, name, price, imageUrl, description);
        var productCreatedDomainEvent = new ProductCreatedDomainEvent(guid);
        product.RaiseDomainEvent(productCreatedDomainEvent);
        return product;
    }
}