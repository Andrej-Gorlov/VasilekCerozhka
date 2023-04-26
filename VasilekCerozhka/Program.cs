using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

//builder.Services.AddCors(c => c.AddPolicy("cors", opt =>
//{
//    opt.AllowAnyHeader();
//    opt.AllowCredentials();
//    opt.AllowAnyMethod();
//    opt.WithOrigins(builder.Configuration.GetSection("Cors:Urls").Get<string[]>()!);
//}));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Register");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Register");
    });


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
//app.UseCors("cors");

//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider;
//    IDbBaseUserInitializer dbInitializer = service.GetRequiredService<IDbBaseUserInitializer>();
//    dbInitializer.Initialize();
//}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();

app.Run();