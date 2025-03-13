using bsg_crud_app.Domain.Entities;
using bsg_crud_app.Domain.Interfaces;
using bsg_crud_app.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Infrastructure.Repositories.Implementations;

public class RepositoryGenerics<T> : IRepositoryGenerics<T> where T : BaseEntity
{
    private readonly CrudAppContext _context;

    protected RepositoryGenerics(CrudAppContext context)
    {
        _context = context;
    }
    
    public T Add(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        _context.Set<T>().Add(entity);
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        var response = await _context.Set<T>().AddAsync(entity);
        return response.Entity;
    }
    
    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<List<T>> GetAllAsync()
    {
        var response = await _context.Set<T>().ToListAsync();
        return response;
    }
    
    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var response = await _context.Set<T>().FindAsync(id);
        return response;
    }

    public T Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Set<T>().Update(entity);
        return entity;
    }
    
    public void Remove(int id)
    {
        var response = GetById(id);
        if (response != null) _context.Set<T>().Remove(response);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
}