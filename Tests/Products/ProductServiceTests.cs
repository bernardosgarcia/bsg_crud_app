using bsg_crud_app.Application.Services.Implementations;
using bsg_crud_app.Domain.Entities;
using bsg_crud_app.Domain.Interfaces;
using bsg_crud_app.Dtos;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Tests.Products;

/// <summary>
/// Test class to product service methods
/// </summary>
public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepository;

    private readonly Mock<IValidator<CreateProductRequestDto>> _mockValidator;

    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _mockRepository = new Mock<IProductRepository>();
        _mockValidator = new Mock<IValidator<CreateProductRequestDto>>();
        _productService = new ProductService(_mockRepository.Object);
    }

    /// <summary>
    /// Test if the product was added
    /// </summary>
    [Fact]
    public async Task Add_Product_Should_Call_Repository_Add()
    {
        var createProductRequestDto = new CreateProductRequestDto("", null, 10);

        _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<ProductEntity>()))
            .ReturnsAsync((ProductEntity p) => p);

        _mockValidator.Setup(validator => validator.ValidateAsync(createProductRequestDto, CancellationToken.None))
            .ReturnsAsync(new ValidationResult());

        var result = await _productService.Create(createProductRequestDto);

        Assert.NotNull(result);
        _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<ProductEntity>()), Times.Once);
    }
}