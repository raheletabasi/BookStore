using BookStore.Domain.Entities;
using BookStore.Domain.Repositories.Generic;

namespace BookStore.Domain.Interface.Repositories;

public interface IPublisherRepository : IGenericRepository<Publisher>
{
    public Task<bool> IsDuplicate(string title);
    public Task<bool> IsDuplicate(Guid id, string title);
}
