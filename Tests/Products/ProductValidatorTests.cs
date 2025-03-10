using bsg_crud_app.Dtos;
using bsg_crud_app.Models;
using bsg_crud_app.Repositories.Interfaces;
using bsg_crud_app.Services.Implementations;
using bsg_crud_app.Validators;
using Moq;

namespace Tests.Products;

public class ProductValidatorTests
{
    private readonly Mock<IProductRepository> _mockRepository;

    public ProductValidatorTests()
    {
        _mockRepository = new Mock<IProductRepository>();
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
    public async Task Return_Errors_When_Duplicate_Name_Validation_Fails()
    {
        var createProductRequestDto = new CreateProductRequestDto("Test One1", null, 1);
        _mockRepository.Setup(repo => repo.GetByNameAsync("Test One")).ReturnsAsync((ProductModel?)null);
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
        var validator = new CreateProductRequestValidator(_mockRepository.Object);
        var validationResult = await validator.ValidateAsync(createProductRequestDto);

        Assert.False(validationResult.IsValid);
    }

}