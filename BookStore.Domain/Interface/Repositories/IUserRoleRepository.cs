using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IUserRoleRepository : IGenericRepository<UserRole>
{
    public Task IsDuplicate(Guid userId, Guid roleId);
}
