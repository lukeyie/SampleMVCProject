using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LukeTest.Models;
using LukeTest.Data.Repositories;
using LukeTest.ViewModels;
using LukeTest.Services;

namespace LukeTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly IAccountService _accountService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, IAccountService accountService)
    {
        _logger = logger;
        _productService = productService;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel viewModel = new();
        IEnumerable<ProductDAO> products = await _productService.GetAllProductsAsync();
        if(products == null)
        {
            ViewBag.Message = "目前沒有商品";
            return View(viewModel);
        }
        
        viewModel.Products = products;

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Register()
    {
        RegisterViewModel viewModel = new();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel)
    {
        //如果資料驗證未通過則回傳原本的View
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        //註冊失敗，回傳錯誤訊息
        if(!await _accountService.RegisterMemberAsync(viewModel.member))
        {
            ViewBag.Message = "帳號已被使用，請重新註冊";
            return View(new RegisterViewModel { member = viewModel.member });
        }

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        LoginViewModel viewModel = new();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Login(string userId, string password)
    {
        //找出符合登入帳號與密碼的 Member資料
        MemberDAO member = await _accountService.GetMemberByUsernameAndPasswordAsync(userId, password);
        if (member == null)
        {
            return View(new LoginViewModel() {errorMessage = "帳號or密碼錯誤，請重新確認登入"});
        }

        HttpContext.Session.SetString("Welcome", $"{member.FullName} 您好");
        
        return RedirectToAction("Index", "Member");
    }
}
