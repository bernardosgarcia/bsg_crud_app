using bsg_crud_app.Models;

namespace bsg_crud_app.Repositories.Interfaces;

public interface IProductRepository : IRepositoryGenerics<ProductModel>
{
    Task<ProductModel?> GetByNameAsync(string productName);
}