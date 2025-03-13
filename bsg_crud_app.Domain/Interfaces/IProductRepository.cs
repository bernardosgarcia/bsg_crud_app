using bsg_crud_app.Models;

namespace bsg_crud_app.Domain.Interfaces;

public interface IProductRepository : IRepositoryGenerics<ProductModel>
{
    Task<ProductModel?> GetByNameAsync(string productName);
}