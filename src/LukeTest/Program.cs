using LukeTest.Interfaces.Repositories;
using LukeTest.Interfaces.Services;
using LukeTest.Repositories;
using LukeTest.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(o => o.LoginPath = new PathString("/Home/Login"));

// Register services
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IAccountService, AccountService>()
    .AddScoped<ICustomAuthenticationService, CustomAuthenticationService>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IMemberRepository, MemberRepository>()
    .AddScoped<IOrderDetailRepository, OrderDetailRepository>()
    .AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapDefaultControllerRoute();

app.Run();
