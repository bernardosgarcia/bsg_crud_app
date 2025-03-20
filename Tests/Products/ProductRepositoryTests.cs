using bsg_crud_app.Domain.Entities;
using bsg_crud_app.Infrastructure.Context;
using bsg_crud_app.Infrastructure.Repositories.Implementations;
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
        var product = new ProductEntity { Name = "Teste", Price = 10 };

        await repository.AddAsync(product);
        await context.SaveChangesAsync();

        var result = await context.ProductEntities.FindAsync(1);
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

        var product = new ProductEntity { Name = "Teste", Price = 10 };
        await context.AddAsync(product);
        await context.SaveChangesAsync();

        var productId = product.Id;

        var existingProduct = await context.ProductEntities.FindAsync(productId);
        Assert.NotNull(existingProduct);

        var oldName = existingProduct.Name;

        existingProduct.Name = "Teste 2";
        repository.Update(existingProduct);
        await context.SaveChangesAsync();

        var updatedProduct = await context.ProductEntities.FindAsync(productId);
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

        var product = new ProductEntity { Name = "Teste", Price = 10 };
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

        var product = new ProductEntity { Name = "Teste", Price = 10 };
        await context.AddAsync(product);

        var product2 = new ProductEntity { Name = "Teste 2", Price = 6 };
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

        var productEntity = new ProductEntity { Name = "Teste", Price = 10 };
        await context.AddAsync(productEntity);
        await context.SaveChangesAsync();

        var existingProduct = await context.ProductEntities.FindAsync(productEntity.Id);

        Assert.NotNull(existingProduct);
        repository.Remove(existingProduct.Id);
        await context.SaveChangesAsync();
        //TODO Change tests (Now remove method has void response)

        //var deletedProduct = await context.ProductEntities.ToListAsync();
        //Assert.Empty(deletedProduct);
    }


}