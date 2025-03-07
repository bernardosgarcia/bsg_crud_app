using bsg_crud_app.Dtos;
using bsg_crud_app.Services.Interfaces;

namespace bsg_crud_app.Services.Implementations;

public class ProductService : IProductService
{
    public async Task<ProductResponseDto> Create(CreateProductRequestDto createProductRequestDto)
    {
        throw new NotImplementedException();
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