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
    private readonly IMemberRepository _memberRepository;

    public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IMemberRepository memberRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
        _memberRepository = memberRepository;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel viewModel = new();
        IEnumerable<ProductDAO> products = await _productRepository.GetAllProductsAsync();
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

        // 如果註冊的帳號不存在，才能執行新增與儲存
        var member = await _memberRepository.GetMemberByUsernameAsync(viewModel.member!.Username);
        if (member == null)
        {
            await _memberRepository.AddMemberAsync(viewModel.member);

            return RedirectToAction("Login");
        }
        ViewBag.Message = "帳號已被使用，請重新註冊";
        return View(new RegisterViewModel { member = viewModel.member });
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
        MemberDAO member = await _memberRepository.GetMemberByUsernameAndPasswordAsync(userId, password);
        if (member == null)
        {
            return View(new LoginViewModel() {errorMessage = "帳號or密碼錯誤，請重新確認登入"});
        }

        HttpContext.Session.SetString("Welcome", $"{member.FullName} 您好");

        return RedirectToAction("Index", "Member");
    }
}
