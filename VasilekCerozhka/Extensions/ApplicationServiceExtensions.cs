using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VasilekCerozhka.Data;
using VasilekCerozhka.Services.Implementations.CouponAPI;
using VasilekCerozhka.Services.Implementations.ProductAPI;

namespace VasilekCerozhka.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
           IConfiguration config)
        {
            // Add services to the container.
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddMemoryCache();

            // Add HttpClient
            services.AddHttpClient<IProductService, ProductService>();
            services.AddHttpClient<IImageService, ImageService>();
            services.AddHttpClient<ICategoryService, CategoryService>();
            services.AddHttpClient<ICouponService, CouponService>();

            StaticDitels.ProductApiBase = config["ServiseUrl:ProductAPI"];
            StaticDitels.CouponApiBase = config["ServiseUrl:CouponAPI"];

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICouponService, CouponService>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            return services;
        }
    }
}
