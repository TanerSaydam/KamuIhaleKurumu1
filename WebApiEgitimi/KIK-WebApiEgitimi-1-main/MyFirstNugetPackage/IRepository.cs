namespace MyFirstNugetPackage;

public interface IRepository<TEntity> 
    where TEntity : class
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void AddRange(IEnumerable<TEntity> entities);
    Task AddRangeAsync(IEnumerable<TEntity> entities,CancellationToken cancellationToken = default);
}
