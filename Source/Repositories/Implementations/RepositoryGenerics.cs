using bsg_crud_app.Context;
using bsg_crud_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Repositories.Implementations;

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
        if (response.Count == 0)
        {
            throw new Exception("No records found.");
        }
        return response;
    }
    
    public T? GetById(int id)
    {
        return _crudAppContext.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var response = await _crudAppContext.Set<T>().FindAsync(id);
        if (response == null)
        {
            throw new Exception("No record found with the specified ID.");
        }
        return response;
    }

    public T Update(T entity)
    {
        _crudAppContext.Set<T>().Update(entity);
        return entity;
    }
    
    public bool Remove(int id)
    {
        var response = GetById(id);
        if (response == null) throw new Exception("No record found with the specified ID.");
        try
        {
            _crudAppContext.Set<T>().Remove(response);
            return true;
        }
        catch
        {
            return false;
        }
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