using System.Configuration;
using EAfspraak.Common;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


var _FileConnectionStrings = builder.Configuration.GetSection("FileConnectionStrings");
builder.Services.Configure<FileConnectionStrings>(_FileConnectionStrings);


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//var config = app.ConfigurationH
// Add services to the container.
//builder.Services.AddOptions();


//builder.Services.Configure<FileConnectionStrings>(app.Configuration.GetSection(nameof(FileConnectionStrings)));


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
