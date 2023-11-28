using Microsoft.EntityFrameworkCore;

namespace MyFirstNugetPackage;

public class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<TEntity> Entity;
    public Repository(TContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }
    public void Add(TEntity entity)
    {
        Entity.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Entity.AddRange(entities);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }
}
