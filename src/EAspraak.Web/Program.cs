using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using EAfspraak.Web.Pages;
using EAfspraak.Services.Interfases;
using EAfspraak.Services.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAfspraakService, AfspraakService>(s => new AfspraakService("Data/"));
builder.Services.AddScoped<ISecurityService, SecurityService>();

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


var app = builder.Build();


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

