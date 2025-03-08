using bsg_crud_app.Dtos;
using bsg_crud_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bsg_crud_app.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ObjectResult> CreateProduct([FromBody] CreateProductRequestDto createProductRequestDto)
    {
        var response = await _productService.Create(createProductRequestDto);
        return new ObjectResponse(response.StatusCode, response);
    }
}