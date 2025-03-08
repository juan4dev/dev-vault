using Catalogo.Domain.Abstractions;

namespace Catalogo.Infrastructure.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly CatalogoDbContext _context;

    public Repository(CatalogoDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync([id], cancellationToken);
    }
}