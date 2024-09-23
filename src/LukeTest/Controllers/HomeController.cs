using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LukeTest.Models;
using LukeTest.Data.Repositories;
using LukeTest.ViewModels;

namespace LukeTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductRepository _productRepository;

    public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel viewModel = new();
        IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();
        viewModel.Products = products;

        return View(viewModel);
    }
}
