using System.Linq.Expressions;

namespace CleanArchitectureApp.Domain.Repositories;

public interface IRepository<TEntity>
{
    Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    Task AddRangeAsync(
        List<TEntity> entities,
        CancellationToken cancellationToken = default);

    void Add(TEntity entity);

    void AddRange(List<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(List<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(List<TEntity> entities);

    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression);

    Task<TEntity> GetOneByExpressionAsync(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default);

    Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default);
}