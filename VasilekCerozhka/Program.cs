using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VasilekCerozhka.Data;
using VasilekCerozhka.Helpers;
using VasilekCerozhka.Services.Implementations.CouponAPI;
using VasilekCerozhka.Services.Implementations.ProductAPI;
using VasilekCerozhka.Services.Interfaces.ICouponAPI;
using VasilekCerozhka.Services.Interfaces.IProductAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddMemoryCache();

// Add HttpClient
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<IImageService, ImageService>();
builder.Services.AddHttpClient<ICategoryService, CategoryService>();
builder.Services.AddHttpClient<ICouponService, CouponService>();

StaticDitels.ProductApiBase = builder.Configuration["ServiseUrl:ProductAPI"];
StaticDitels.CouponApiBase = builder.Configuration["ServiseUrl:CouponAPI"];

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICouponService, CouponService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();