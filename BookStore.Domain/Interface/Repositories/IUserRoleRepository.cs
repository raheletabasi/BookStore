using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IUserRoleRepository : IGenericRepository<UserRole>
{
    public Task<bool> IsDuplicate(Guid userId, Guid roleId);
    public Task<bool> IsDuplicate(Guid id,Guid userId, Guid roleId);
}
