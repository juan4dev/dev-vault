using Catalogo.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(CatalogoDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>().ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByCode(string code, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Product>()
                             .FirstOrDefaultAsync(p => p.Code == code, cancellationToken);
    }
}