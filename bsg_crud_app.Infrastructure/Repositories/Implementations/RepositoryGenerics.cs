using bsg_crud_app.Context;
using bsg_crud_app.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Infrastructure.Repositories.Implementations;

public class RepositoryGenerics<T> : IRepositoryGenerics<T> where T : class
{
    private readonly CrudAppContext _crudAppContext;

    protected RepositoryGenerics(CrudAppContext crudAppContext)
    {
        _crudAppContext = crudAppContext;
    }
    
    public T Add(T entity)
    {
        _crudAppContext.Set<T>().Add(entity);
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        var response = await _crudAppContext.Set<T>().AddAsync(entity);
        return response.Entity;
    }
    
    public List<T> GetAll()
    {
        return _crudAppContext.Set<T>().ToList();
    }

    public async Task<List<T>> GetAllAsync()
    {
        var response = await _crudAppContext.Set<T>().ToListAsync();
        return response;
    }
    
    public T? GetById(int id)
    {
        return _crudAppContext.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var response = await _crudAppContext.Set<T>().FindAsync(id);
        return response;
    }

    public T Update(T entity)
    {
        _crudAppContext.Set<T>().Update(entity);
        return entity;
    }
    
    public void Remove(int id)
    {
        var response = GetById(id);
        if (response != null) _crudAppContext.Set<T>().Remove(response);
    }

    public void SaveChange()
    {
        _crudAppContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _crudAppContext.SaveChangesAsync();
    }
    
}