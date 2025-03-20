using bsg_crud_app.Application.Validators;
using bsg_crud_app.Domain.Entities;
using bsg_crud_app.Domain.Interfaces;
using bsg_crud_app.Dtos;
using Moq;

namespace Tests.Products;

/// <summary>
/// Test class to product validator from FluentValidator lib
/// </summary>
public class ProductValidatorTests
{
    private readonly Mock<IProductRepository> _mockRepository;

    public ProductValidatorTests()
    {
        _mockRepository = new Mock<IProductRepository>();
    }

    /// <summary>
    ///
    /// </summary>
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
    public async Task Return_Errors_When_Duplicate_Name_Validation_Fails()
    {
        var createProductRequestDto = new CreateProductRequestDto("Test One1", null, 1);
        _mockRepository.Setup(repo => repo.GetByNameAsync("Test One")).ReturnsAsync((ProductEntity?)null);
        await Validation_Fails_Base_Test(createProductRequestDto);
    }

    [Fact]
    public async Task Return_Errors_When_Length_Name_Validation_Fails()
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
        var validator = new CreateProductRequestValidator(_mockRepository.Object);
        var validationResult = await validator.ValidateAsync(createProductRequestDto);

        Assert.False(validationResult.IsValid);
    }

}