using Catalogo.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly CatalogoDbContext _context;

    public Repository(CatalogoDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync([id], cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>()
                             .AsNoTracking()
                             .ToListAsync(cancellationToken);
    }
}