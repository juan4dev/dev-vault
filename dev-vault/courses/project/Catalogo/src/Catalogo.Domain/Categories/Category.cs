using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Categories.Events;

namespace Catalogo.Domain.Categories;

public class Category : Entity
{
    public string Name { get; set; }

    private Category(Guid id) : base(id)
    {
    }

    public static Category Create(string name)
    {
        var id = Guid.CreateVersion7();
        var category = new Category(id)
        {
            Name = name
        };

        var domainEvent = new CategoryCreatedEvent(id);
        category.RaiseDomainEvent(domainEvent);

        return category;
    }
}