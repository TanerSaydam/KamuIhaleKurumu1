using Microsoft.EntityFrameworkCore;

namespace MyFirstNugetPackage;

public interface IUnitOfWork<TContext>
    where TContext: DbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
