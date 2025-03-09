using bsg_crud_app.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace bsg_crud_app.Services.Interfaces;

public interface IProductService
{
    Task<GenericResponse<ProductResponseDto>> Create(CreateProductRequestDto createProductRequestDto);
    Task<List<ProductResponseDto>> ReadAll();
    Task<ProductResponseDto> ReadById(int productId);
    Task<GenericResponse<ProductResponseDto>> Update(int productId, UpdateProductRequestDto updateProductRequestDto);
    Task<GenericResponse<string>> Delete(int productId);
}