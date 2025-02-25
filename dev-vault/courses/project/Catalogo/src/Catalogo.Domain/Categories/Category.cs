
using Catalogo.Domain.Abstractions;
using Catalogo.Domain.Categories.Events;

namespace Catalogo.Domain.Categories;

public class Category : Entity
{

    public string? Name { get; private set; }

    private Category(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static Category Create(string name)
    {
        var id = Guid.NewGuid();
        var category = new Category(id, name);

        var domainEvent = new CategoryCreatedEvent(id);
        category.RaiseDomainEvent(domainEvent);

        return category;
    }
}