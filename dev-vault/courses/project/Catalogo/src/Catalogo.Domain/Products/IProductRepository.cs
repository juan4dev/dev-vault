namespace Catalogo.Domain.Products;

public interface IProductRepository
{
    Task AddAsync(Product product);

    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product> GetByIdAsync(Guid id);

    Task<Product> GetByCode(string code);
}