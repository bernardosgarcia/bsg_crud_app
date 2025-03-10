using bsg_crud_app.Dtos;
using bsg_crud_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bsg_crud_app.Controllers.ApiControllers;

/// <summary>
/// Controller class to access product services
/// </summary>
[Route("Product")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="productService"></param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="createProductRequestDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ObjectResult> CreateProduct([FromBody] CreateProductRequestDto createProductRequestDto)
    {
        var response = await _productService.Create(createProductRequestDto);
        return new ObjectResponse(response.StatusCode, response);
    }

    /// <summary>
    /// Read all existing products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ObjectResult> ReadProducts()
    {
        var response = await _productService.ReadAll();
        return new ObjectResponse(response.StatusCode, response);
    }

    /// <summary>
    /// Read existing product by id
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet("{productId:int}")]
    public async Task<ObjectResult> ReadProductById(int productId)
    {
        var response = await _productService.ReadById(productId);
        return new ObjectResponse(response.StatusCode, response);
    }

    /// <summary>
    /// Compare old values and update existing product
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="updateProductRequestDto"></param>
    /// <returns></returns>
    [HttpPatch("{productId:int}")]
    public async Task<ObjectResult> UpdateProduct(
        int productId,
        [FromBody] UpdateProductRequestDto updateProductRequestDto)
    {
        var response = await _productService.Update(productId, updateProductRequestDto);
        return new ObjectResponse(response.StatusCode, response);
    }

    /// <summary>
    /// Delete existing product by id
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpDelete("{productId:int}")]
    public async Task<ObjectResult> DeleteProduct(int productId)
    {
        var response = await _productService.Delete(productId);
        return new ObjectResponse(response.StatusCode, response);
    }
}