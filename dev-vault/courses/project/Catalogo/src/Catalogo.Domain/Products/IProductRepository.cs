namespace Catalogo.Domain.Products;

public interface IProductRepository
{
    Task AddAsync(Product product);

    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Product?> GetByCode(string code, CancellationToken cancellationToken = default);
}