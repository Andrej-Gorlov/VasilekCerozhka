using Microsoft.AspNetCore.Authentication.Cookies;
using VasilekCerozhka.Services;
using VasilekCerozhka.Services.Implementations.AccountsAPI;
using VasilekCerozhka.Services.Interfaces.IAccountsAPI;
using IBaseService = VasilekCerozhka.Services.IBaseService;

namespace VasilekCerozhka.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
           IConfiguration config)
        {
            services.AddMemoryCache();
            // Add HttpClient
            services.AddHttpClient<IProductService, ProductService>();
            services.AddHttpClient<IImageService, ImageService>();
            services.AddHttpClient<ICategoryService, CategoryService>();
            services.AddHttpClient<ICouponService, CouponService>();

            StaticDitels.ProductApiBase = config["ServiseUrl:ProductAPI"];
            StaticDitels.CouponApiBase = config["ServiseUrl:CouponAPI"];
            StaticDitels.AuthApiBase = config["ServiseUrl:AuthAPI"];

            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICouponService, CouponService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(10);
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });

            services.AddControllersWithViews();
            return services;
        }
    }
}
