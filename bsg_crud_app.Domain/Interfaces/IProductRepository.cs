using bsg_crud_app.Domain.Entities;

namespace bsg_crud_app.Domain.Interfaces;

public interface IProductRepository : IRepositoryGenerics<ProductEntity>
{
    Task<ProductEntity?> GetByNameAsync(string productName);
}