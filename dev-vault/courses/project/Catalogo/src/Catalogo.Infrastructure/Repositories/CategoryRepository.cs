using Catalogo.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(CatalogoDbContext context) : base(context)
    {
    }
}