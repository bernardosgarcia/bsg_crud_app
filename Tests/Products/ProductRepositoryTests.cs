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
        await context.AddAsync(product);
        await context.SaveChangesAsync();

        var productId = product.Id;

        var existingProduct = await context.ProductModels.FindAsync(productId);
        Assert.NotNull(existingProduct);

        var oldName = existingProduct.Name;

        existingProduct.Name = "Teste 2";
        repository.Update(existingProduct);
        await context.SaveChangesAsync();

        var updatedProduct = await context.ProductModels.FindAsync(productId);
        Assert.NotNull(updatedProduct);
        Assert.NotEqual(oldName, updatedProduct.Name);
        Assert.Equal("Teste 2", updatedProduct.Name);
    }

    /// <summary>
    /// Test to read only one registry by id
    /// </summary>
    [Fact]
    public async Task Read_By_Id_Should_Return_Entity()
    {
        await using var context = new CrudAppContext(_options);
        var repository = new ProductRepository(context);

        var product = new ProductModel { Name = "Teste", Price = 10 };
        await context.AddAsync(product);
        await context.SaveChangesAsync();

        var existingProduct = await repository.GetByIdAsync(product.Id);
        Assert.NotNull(existingProduct);
        Assert.Equal(product.Name, existingProduct.Name);
    }

    /// <summary>
    /// Test to read all registry
    /// </summary>
    [Fact]
    public async Task Read_All_Should_Return_Entity()
    {
        await using var context = new CrudAppContext(_options);
        var repository = new ProductRepository(context);

        var product = new ProductModel { Name = "Teste", Price = 10 };
        await context.AddAsync(product);

        var product2 = new ProductModel { Name = "Teste 2", Price = 6 };
        await context.AddAsync(product2);

        await context.SaveChangesAsync();

        var productEntities = await repository.GetAllAsync();

        Assert.NotEmpty(productEntities);
        Assert.NotNull(productEntities);
        Assert.Equal(2, productEntities.Count);
    }

    /// <summary>
    /// Test to delete existing a product entity
    /// </summary>
    [Fact]
    public async Task Delete_Should_Delete_Entity()
    {
        await using var context = new CrudAppContext(_options);
        var repository = new ProductRepository(context);

        var productEntity = new ProductModel { Name = "Teste", Price = 10 };
        await context.AddAsync(productEntity);
        await context.SaveChangesAsync();

        var existingProduct = await context.ProductModels.FindAsync(productEntity.Id);

        Assert.NotNull(existingProduct);
        var isDeleted = repository.Remove(existingProduct.Id);
        await context.SaveChangesAsync();

        var deletedProduct = await context.ProductModels.ToListAsync();
        Assert.True(isDeleted);
        Assert.Empty(deletedProduct);
    }


}