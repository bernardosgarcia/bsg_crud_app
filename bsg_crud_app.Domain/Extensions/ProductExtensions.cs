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
    public static ProductModel ToEntity(this CreateProductRequestDto createProductRequestDto) => new()
    {
        Name = createProductRequestDto.Name,
        Description = createProductRequestDto.Description,
        Price = createProductRequestDto.Price
    };

    /// <summary>
    /// Map entity to response dto
    /// </summary>
    /// <param name="productModel"></param>
    /// <returns></returns>
    public static ProductResponseDto ToDto(this ProductModel productModel) => new
    (
        productModel.Id,
        productModel.Name,
        productModel.Description,
        productModel.Price,
        productModel.CreatedAt,
        productModel.UpdatedAt
    );

    /// <summary>
    /// Map entity and update request dto to patch method
    /// </summary>
    /// <param name="productEntity"></param>
    /// <param name="updateProductRequestDto"></param>
    public static void Mapper(this ProductModel productEntity, UpdateProductRequestDto updateProductRequestDto)
    {
        var updated = false;

        if (updateProductRequestDto.Name != null && productEntity.Name != updateProductRequestDto.Name)
        {
            productEntity.Name = updateProductRequestDto.Name;
            updated = true;
        }
        if (updateProductRequestDto.Description != null && productEntity.Description != updateProductRequestDto.Description)
        {
            productEntity.Description = updateProductRequestDto.Description;
            updated = true;
        }
        if (updateProductRequestDto.Price != null && productEntity.Price != updateProductRequestDto.Price.Value)
        {
            productEntity.Price = updateProductRequestDto.Price.Value;
            updated = true;
        }

        if (updated)
        {
            productEntity.UpdatedAt = DateTime.UtcNow;
        }
    }
}