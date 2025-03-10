using System.Diagnostics;
using bsg_crud_app.Dtos;
using bsg_crud_app.Models;
using bsg_crud_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bsg_crud_app.Controllers.MvcControllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _productService.ReadAll();
        return View(response.Data);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View("_CreateProduct");
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequestDto createProductRequestDto)
    {
        if (ModelState.IsValid)
        {
            await _productService.Create(createProductRequestDto);
            return RedirectToAction("Index");
        }
        return View("_CreateProduct", createProductRequestDto);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
