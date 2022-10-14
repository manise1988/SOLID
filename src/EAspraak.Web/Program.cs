using System.Configuration;
using Microsoft.Extensions.Configuration;
using EAfspraak.Services.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAfspraakService, AfspraakService>();

builder.Services.AddRazorPages();

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

