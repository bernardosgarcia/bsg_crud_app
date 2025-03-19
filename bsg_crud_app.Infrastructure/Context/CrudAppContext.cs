using bsg_crud_app.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bsg_crud_app.Infrastructure.Context;

/// <summary>
/// Define mains database context configs
/// </summary>
public class CrudAppContext : DbContext
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options"></param>
    public CrudAppContext(DbContextOptions<CrudAppContext> options) : base(options) { }

    /// <summary>
    /// Table "products"
    /// </summary>
    public DbSet<ProductEntity> ProductEntities { get; init; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //
    //     base.OnModelCreating(modelBuilder);
    // }

}