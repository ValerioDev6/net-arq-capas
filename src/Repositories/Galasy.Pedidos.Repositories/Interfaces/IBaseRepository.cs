using System.Linq.Expressions;
using Galasy.Pedidos.Entities;

namespace Galasy.Pedidos.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity 
{
    Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);

    Task<(ICollection<TResult> Collection, int TotalRows)> ListAsync<TResult, TKey>
    (
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, TEntity>> orderBy,
        int page = 1, int rows = 10
    );
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    
    Task UpdateAsync();
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id); 
}