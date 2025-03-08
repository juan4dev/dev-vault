namespace Catalogo.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(Category category);

    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
}