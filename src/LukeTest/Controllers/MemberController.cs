using LukeTest.Services;
using LukeTest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LukeTest.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IProductService _productService;
        private readonly IAuthenticationService _authenticationService;

        public MemberController(ILogger<MemberController> logger, IProductService productService, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _productService = productService;
            _authenticationService = authenticationService;
        }

        public async Task<ActionResult> Index()
        {
            HomeIndexViewModel viewModel = new();
            viewModel.Products = await _productService.GetAllProductsAsync();
            if(viewModel.Products == null)
            {
                ViewBag.Message = "目前沒有商品";
                return View(viewModel);
            }

            ViewData["Layout"] = "_MemberLayout";
            return View("../Home/Index", viewModel);
        }

        public async Task<ActionResult> Logout()
        {
            await _authenticationService.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }
    }
}