using LukeTest.Services;
using LukeTest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LukeTest.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public MemberController(ILogger<MemberController> logger, IAuthenticationService authenticationService, IProductService productService, IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _authenticationService = authenticationService;
            _orderService = orderService;
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

        public ActionResult ShoppingCart()
        {
            MemberShoppingCartViewModel viewModel = new();
            string userId = User.Identity.Name;

            viewModel.OrderDetails = _orderService.GetOrderDetailByUserId(userId, false);
            return View(viewModel);
        }
    }
}