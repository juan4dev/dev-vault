namespace Catalogo.Domain.Categories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);

    Task<IEnumerable<Category>> GetAllAsync();
}