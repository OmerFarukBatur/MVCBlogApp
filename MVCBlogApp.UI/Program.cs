using Microsoft.AspNetCore.Authentication.Cookies;
using MVCBlogApp.Application;
using MVCBlogApp.Infrastructure;
using MVCBlogApp.Infrastructure.Services.Storage.Local;
using MVCBlogApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();


builder.Services.AddStorage<LocalStorage>();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.Cookie.Name = "LoginUser";
    x.LoginPath = "/Home/Login/";
    x.AccessDeniedPath = "/Home/Login/";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UIHome}/{action=Index}/{id?}");

app.Run();
