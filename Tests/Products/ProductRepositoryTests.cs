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
    /// Test to add a new product
    /// </summary>
    [Fact]
    public async Task Add_Should_Add_Entity()
    {
        await using var context = new CrudAppContext(_options);
        var repository = new ProductRepository(context);
        var product = new ProductModel { Name = "Teste", Price = 10 };

        await repository.AddAsync(product);
        await context.SaveChangesAsync();

        var result = await context.ProductModels.FindAsync(1);
        Assert.NotNull(result);
        Assert.Equal("Teste", result.Name);

    }

    /// <summary>
    /// Test to verify update repository method
    /// </summary>
    [Fact]
    public async Task Update_Should_Update_Entity()
    {
        await using var context = new CrudAppContext(_options);
        var repository = new ProductRepository(context);

        var product = new ProductModel { Name = "Teste", Price = 10 };
        await repository.AddAsync(product);
        await repository.SaveChangesAsync();

        var productId = product.Id;

        var existingProduct = await context.ProductModels.FindAsync(productId);
        Assert.NotNull(existingProduct);

        var oldName = existingProduct.Name;

        existingProduct.Name = "Teste 2";
        repository.Update(existingProduct);
        await repository.SaveChangesAsync();

        var updatedProduct = await context.ProductModels.FindAsync(productId);
        Assert.NotNull(updatedProduct);
        Assert.NotEqual(oldName, updatedProduct.Name);
        Assert.Equal("Teste 2", updatedProduct.Name);
    }
}