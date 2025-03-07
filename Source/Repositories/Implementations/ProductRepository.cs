using bsg_crud_app.Context;
using bsg_crud_app.Models;
using bsg_crud_app.Repositories.Interfaces;

namespace bsg_crud_app.Repositories.Implementations;

public class ProductRepository : RepositoryGenerics<ProductModel>, IProductRepository
{
    private readonly CrudAppContext _crudAppContext;

    public ProductRepository(CrudAppContext crudAppContext) : base(crudAppContext)
    {
        _crudAppContext = crudAppContext;
    }
}