using System.Net;
using bsg_crud_app.Dtos;
using bsg_crud_app.Extensions;
using bsg_crud_app.Repositories.Implementations;
using bsg_crud_app.Repositories.Interfaces;
using bsg_crud_app.Services.Interfaces;
using bsg_crud_app.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bsg_crud_app.Services.Implementations;

/// <summary>
///
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductRequestDto> _validator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="productRepository"></param>
    /// <param name="validator"></param>
    public ProductService(
        IProductRepository productRepository,
        IValidator<CreateProductRequestDto> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="createProductRequestDto"></param>
    /// <returns></returns>
    public async Task<GenericResponse<ProductResponseDto>> Create(CreateProductRequestDto createProductRequestDto)
    {
        var validationResult = await _validator.ValidateAsync(createProductRequestDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return new GenericResponse<ProductResponseDto>(HttpStatusCode.BadRequest, errors);
        }

        var productEntity = createProductRequestDto.toEntity();

        var responseProductEntity = await _productRepository.AddAsync(productEntity);
        await _productRepository.SaveChangesAsync();

        return new GenericResponse<ProductResponseDto>(HttpStatusCode.OK, responseProductEntity.toDto());
    }

    public async Task<List<ProductResponseDto>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponseDto> ReadById(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponseDto> Update(int productId, UpdateProductRequestDto updateProductRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponseDto> Delete(int productId)
    {
        throw new NotImplementedException();
    }
}