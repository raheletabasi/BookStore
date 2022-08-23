﻿using BookStore.Domain.Common;
using BookStore.Domain.Repositories.Generic;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AuditableBaseEntity
{
    private readonly BookStoreContext _context;
    private readonly DbSet<TEntity> _entity;

    public GenericRepository(BookStoreContext context)
    {
        _context = context;
        _entity = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        _entity.AddAsync(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _entity.Remove(entity);
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return (Task<IEnumerable<TEntity>>)_entity.AsAsyncEnumerable();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _entity.FirstOrDefaultAsync(s => s.Id.Equals(id));
    }

    public async Task Save()
    {
        _context.SaveChanges();
    }

    public Task SoftDelete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdaeAsync(TEntity entity)
    {
        _entity.Update(entity);
    }
}