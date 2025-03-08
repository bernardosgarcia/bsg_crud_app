using bsg_crud_app.Dtos;
using bsg_crud_app.Models;
using bsg_crud_app.Repositories.Interfaces;
using bsg_crud_app.Services.Implementations;
using bsg_crud_app.Validators;
using FluentValidation.Results;
using Moq;

namespace Tests.Products;

public class ProductValidatorTests
{
    private readonly Mock<IProductRepository> _mockRepository;
    private readonly Mock<FluentValidation.IValidator<CreateProductRequestDto>> _mockValidator;
    private readonly ProductService _productService;

    public ProductValidatorTests()
    {
        _mockRepository = new Mock<IProductRepository>();
        _mockValidator = new Mock<FluentValidation.IValidator<CreateProductRequestDto>>();
        _productService = new ProductService(_mockRepository.Object, _mockValidator.Object);
    }

    [Fact]
    public async Task Return_Errors_When_Price_Validation_Fails()
    {
        var createProductRequestDto = new CreateProductRequestDto("Teste", null, 0);
        await Validation_Fails_Base_Test(createProductRequestDto);
    }

    [Fact]
    public async Task Return_Errors_When_Null_Name_Validation_Fails()
    {
        var createProductRequestDto = new CreateProductRequestDto("", null, 10);
        await Validation_Fails_Base_Test(createProductRequestDto);
    }

    [Fact]
    public async Task Return_Errors_When_Lenght_Name_Validation_Fails()
    {
        //Create an input DTO simulating a string with 101 characters.
        var createProductRequestDto = new CreateProductRequestDto
        (
            new string('T', 101),
            null,
            10
        );
        await Validation_Fails_Base_Test(createProductRequestDto);
    }

    private async Task Validation_Fails_Base_Test(CreateProductRequestDto createProductRequestDto)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(createProductRequestDto);

        _mockValidator
            .Setup(v => v.ValidateAsync(createProductRequestDto, CancellationToken.None))
            .ReturnsAsync(validationResult);

        var result = await _productService.Create(createProductRequestDto);

        Assert.NotNull(result);
        Assert.NotNull(validationResult);
        Assert.Equal(validationResult.Errors.Count, result.Errors?.Count);

        _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<ProductModel>()), Times.Never);
    }

}