
using Catalogo.Domain.Abstractions;

namespace Catalogo.Domain.Categories;

public class Category : Entity
{

    public string? Name { get; private set; }

    public Category(Guid id, string name) : base(id)
    {
    }
}