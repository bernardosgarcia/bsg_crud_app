using bsg_crud_app.Dtos;
using bsg_crud_app.Extensions;
using bsg_crud_app.Models;
using bsg_crud_app.Repositories.Interfaces;
using bsg_crud_app.Services.Implementations;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Tests.Products;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepository;
    private readonly Mock<IValidator<CreateProductRequestDto>> _mockValidator;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _mockRepository = new Mock<IProductRepository>();
        _mockValidator = new Mock<IValidator<CreateProductRequestDto>>();
        _productService = new ProductService(_mockRepository.Object, _mockValidator.Object);
    }

    [Fact]
    public async Task AddProduct_Should_Call_Repository_Add()
    {
        var createProductRequestDto = new CreateProductRequestDto("", null, 10);

        _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<ProductModel>()))
            .ReturnsAsync((ProductModel p) => p);

        _mockValidator.Setup(validator => validator.ValidateAsync(createProductRequestDto, CancellationToken.None))
            .ReturnsAsync(new ValidationResult());

        var result = await _productService.Create(createProductRequestDto);

        Assert.NotNull(result);
        _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<ProductModel>()), Times.Once);
    }
}