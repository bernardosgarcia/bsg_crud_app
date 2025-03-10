using System.Net;
using bsg_crud_app.Dtos;
using bsg_crud_app.Extensions;
using bsg_crud_app.Repositories.Interfaces;
using bsg_crud_app.Services.Interfaces;
using bsg_crud_app.Validators;

namespace bsg_crud_app.Services.Implementations;

/// <summary>
/// Product service to CRUD
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="productRepository"></param>
    public ProductService(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="createProductRequestDto"></param>
    /// <returns></returns>
    public async Task<GenericResponse<ProductResponseDto>> Create(CreateProductRequestDto createProductRequestDto)
    {
        var createProductValidator = new CreateProductRequestValidator(_productRepository);
        var validationResult = await createProductValidator.ValidateAsync(createProductRequestDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return new GenericResponse<ProductResponseDto>(HttpStatusCode.BadRequest, errors);
        }

        var productEntity = createProductRequestDto.ToEntity();

        var responseProductEntity = await _productRepository.AddAsync(productEntity);
        await _productRepository.SaveChangesAsync();

        var responseProductDto = responseProductEntity.ToDto();
        return new GenericResponse<ProductResponseDto>(HttpStatusCode.OK, responseProductDto);
    }

    /// <summary>
    /// Read all existing products
    /// </summary>
    /// <returns></returns>
    public async Task<GenericResponse<List<ProductResponseDto>>> ReadAll()
    {
        var productEntities = await _productRepository.GetAllAsync();

        var productResponseDtos = productEntities.Select(productEntity
            => productEntity.ToDto()).ToList();
        return new GenericResponse<List<ProductResponseDto>>(HttpStatusCode.OK, productResponseDtos);
    }

    /// <summary>
    /// Read existing product by id
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<GenericResponse<ProductResponseDto>> ReadById(int productId)
    {
        var productEntity = await _productRepository.GetByIdAsync(productId);
        if (productEntity == null) throw new KeyNotFoundException();

        var productResponseDto = productEntity.ToDto();
        return new GenericResponse<ProductResponseDto>(HttpStatusCode.OK, productResponseDto);
    }

    /// <summary>
    /// Compare old values and update existing product
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="updateProductRequestDto"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<GenericResponse<ProductResponseDto>> Update(int productId, UpdateProductRequestDto updateProductRequestDto)
    {
        var updateProductValidator = new UpdateProductRequestValidator();
        var validationResult = await updateProductValidator.ValidateAsync(updateProductRequestDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return new GenericResponse<ProductResponseDto>(HttpStatusCode.BadRequest, errors);
        }

        var productEntity = await _productRepository.GetByIdAsync(productId);
        if (productEntity == null) throw new KeyNotFoundException();
        productEntity.Mapper(updateProductRequestDto);

        _productRepository.Update(productEntity);
        await _productRepository.SaveChangesAsync();

        var productResponseDto = productEntity.ToDto();
        return new GenericResponse<ProductResponseDto>(HttpStatusCode.OK, productResponseDto);
    }

    /// <summary>
    /// Delete existing product by id
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<GenericResponse<string>> Delete(int productId)
    {
        _productRepository.Remove(productId);
        await _productRepository.SaveChangesAsync();

        return new GenericResponse<string>(HttpStatusCode.OK, "Resource deleted successfully.");
    }
}