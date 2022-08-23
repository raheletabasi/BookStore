using BookStore.Domain.Entity;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> IsDuplicate(string userName, string email);
    public Task<bool> IsDuplicate(Guid id, string userName, string email);
    public Task<User> GetUserByUserName(string userName);
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserByMobile(string mobile);
}
