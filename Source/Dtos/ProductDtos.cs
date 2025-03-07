namespace bsg_crud_app.Dtos;

/// <summary>
/// DTO for creating a new product.
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
public record CreateProductRequestDto(
    string Name,
    string Description,
    decimal Price
);

/// <summary>
/// DTO for update an existing product
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
public record UpdateProductRequestDto(
    string? Name,
    string? Description,
    decimal? Price
);

/// <summary>
/// Response DTO containing detailed product information.
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
/// <param name="CreatedAt"></param>
/// <param name="UpdatedAt"></param>
public record ProductResponseDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt,
    DateTime UpdatedAt
);