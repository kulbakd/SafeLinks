using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SafeLinks.Core.Application.Interfaces.Repositories;
using SafeLinks.Infrastructure.Contexts;

namespace SafeLinks.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly SafeLinksDbContext _dbContext;

    public Repository(SafeLinksDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public IQueryable<TEntity> Entities => _dbContext.Set<TEntity>();

    private DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);

        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        DbSet.Update(entity);

        return entity;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.Where(predicate);
    }
}