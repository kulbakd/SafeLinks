using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SafeLinks.Core.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    public IQueryable<TEntity> Entities { get; }
    public Task<TEntity> AddAsync(TEntity entity);
    public TEntity Update(TEntity entity);
    public void Delete(TEntity entity);
    public Task<int> SaveChangesAsync();
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
}