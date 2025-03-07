using bsg_crud_app.Models;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Context;

public class CrudAppContext : DbContext
{
    public CrudAppContext(DbContextOptions<CrudAppContext> options) : base(options) { }

    public DbSet<ProductModel> ProductModels { get; set; }
}