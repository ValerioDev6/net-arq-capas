using System.Linq.Expressions;
using Galasy.Pedidos.DataAccess.Context;
using Galasy.Pedidos.Entities;
using Galasy.Pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Galasy.Pedidos.Repositories.Implementations;

public class BaseRepository<TEntity> :IBaseRepository<TEntity> where TEntity: BaseEntity
{
    protected readonly DbDatabaseContext _context;
    public BaseRepository(DbDatabaseContext context)
    {
        _context = context;
    }

    public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>()
            .Where(predicate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<(ICollection<TResult> Collection, int TotalRows)> ListAsync<TResult, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, TEntity>> orderBy, int page = 1,
        int rows = 10)
    {
        var result = await _context.Set<TEntity>()
            .Where(predicate)
            .AsNoTracking()
            .OrderBy(orderBy)
            .Skip((page - 1) * rows)
            .Take(rows)
            .Select(selector)
            .ToListAsync();

        var total = await _context.Set<TEntity>().Where(predicate).CountAsync();
        return (result, total);
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id && p.Estado );
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = _context.Set<TEntity>().Add(entity);

        foreach (var entry in _context.ChangeTracker.Entries<BaseEntity>()
                     .Where(e => e.State == EntityState.Added))
        {
            if (entry.Entity.Id <= 0)
            {
                entry.Entity.Id = await GetNextIdAsync(entry.Entity.GetType());
            }
        }

        await _context.SaveChangesAsync();
        return result.Entity;
    }

    private async Task<int> GetNextIdAsync(Type entityType)
    {
        var entityTypeInfo = _context.Model.FindEntityType(entityType);
        var table = entityTypeInfo?.GetTableName();
        var schema = entityTypeInfo?.GetSchema() ?? "dbo";

        if (string.IsNullOrEmpty(table))
        {
            throw new InvalidOperationException($"No se pudo resolver la tabla para '{entityType.Name}'.");
        }

        var query = $"SELECT ISNULL(MAX([Id]), 0) + 1 AS [Value] FROM [{schema}].[{table}]";
        return await _context.Database.SqlQueryRaw<int>(query).FirstAsync();
    }

    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Set<TEntity>()
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(p => p.SetProperty(p => p.Estado, false));
    }
}
