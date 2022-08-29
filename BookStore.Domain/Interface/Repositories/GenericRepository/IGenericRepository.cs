using BookStore.Domain.Common;

namespace BookStore.Domain.Repositories.Generic;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public Task AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity> GetByIdAsync(Guid id);
    public Task SoftDelete(Guid id);
    public Task<bool> IsExist(Guid id);
    public Task Save();
}
