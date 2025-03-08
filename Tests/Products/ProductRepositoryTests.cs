using bsg_crud_app.Context;
using bsg_crud_app.Models;
using bsg_crud_app.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Tests.Products;

/// <summary>
/// Class to test crud interface repository
/// </summary>
public class ProductRepositoryTests
{
    private readonly DbContextOptions<CrudAppContext> _options;

    /// <summary>
    /// Constructor
    /// </summary>
    public ProductRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<CrudAppContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
    }

    /// <summary>
    /// Test to add a new product at db
    /// </summary>
    [Fact]
    public async Task Add_Should_Add_Entity()
    {
        await using var context = new CrudAppContext(_options);
        var repository = new ProductRepository(context);
        var product = new ProductModel { Id = 1, Name = "Teste", Price = 10 };

        await repository.AddAsync(product);
        await context.SaveChangesAsync();

        var result = await context.ProductModels.FindAsync(1);
        Assert.NotNull(result);
        Assert.Equal("Teste", result.Name);

    }
}