using bsg_crud_app.Domain.Entities;
using bsg_crud_app.Domain.Interfaces;
using bsg_crud_app.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Infrastructure.Repositories.Implementations;

public class ProductRepository : RepositoryGenerics<ProductEntity>, IProductRepository
{
    private readonly CrudAppContext _crudAppContext;

    public ProductRepository(CrudAppContext crudAppContext) : base(crudAppContext)
    {
        _crudAppContext = crudAppContext;
    }

    public async Task<ProductEntity?> GetByNameAsync(string productName)
    {
        return await _crudAppContext.ProductModels.FirstOrDefaultAsync(y => y.Name == productName);
    }
}