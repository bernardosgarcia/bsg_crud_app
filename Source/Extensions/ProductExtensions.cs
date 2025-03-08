using bsg_crud_app.Dtos;
using bsg_crud_app.Models;

namespace bsg_crud_app.Extensions;

/// <summary>
/// Extension class to map entity and dto
/// </summary>
public static class ProductExtensions
{
    /// <summary>
    /// Map create request dto to entity
    /// </summary>
    /// <param name="createProductRequestDto"></param>
    /// <returns></returns>
    public static ProductModel toEntity(this CreateProductRequestDto createProductRequestDto) => new()
    {
        Name = createProductRequestDto.Name,
        Description = createProductRequestDto.Description,
        Price = createProductRequestDto.Price,
        CreatedAt = null
    };

    /// <summary>
    /// Map entity to response dto
    /// </summary>
    /// <param name="productModel"></param>
    /// <returns></returns>
    public static ProductResponseDto toDto(this ProductModel productModel) => new
    (
        productModel.Id,
        productModel.Name,
        productModel.Description,
        productModel.Price,
        productModel.CreatedAt ?? default,
        productModel.UpdatedAt
    );
}