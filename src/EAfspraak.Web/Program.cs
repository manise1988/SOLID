using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using EAfspraak.Web.Pages;
using EAfspraak.Web.Services;
using EAfspraak.Domain.Interfaces;
using EAfspraak.Infrastructure;
using EAfspraak.Domain.Manager;

var builder = WebApplication.CreateBuilder(args);
//IRepositoryAfspraak repository = new RepositoryManager();
//builder.Services.AddScoped<IAfspraakManager, AfspraakManager>(s=> new (repository));
//builder.Services.AddScoped<IBerekeningManager, BerekeningManager>(s=> new (repository);

builder.Services.AddRazorPages();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/index/logout";
    options.AccessDeniedPath = "/accessdenied";
});



// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.Run();
