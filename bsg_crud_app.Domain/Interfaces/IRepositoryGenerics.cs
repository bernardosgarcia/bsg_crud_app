using bsg_crud_app.Domain.Entities;

namespace bsg_crud_app.Domain.Interfaces;

public interface IRepositoryGenerics<T> where T : BaseEntity
{
    T? Add(T entity);
    Task<T> AddAsync(T entity);
    List<T> GetAll();
    Task<List<T>> GetAllAsync();
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);
    T Update(T entity);
    void Remove(int id);
    void SaveChange();
    Task SaveChangesAsync();
}