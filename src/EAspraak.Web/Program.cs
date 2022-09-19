using System.Configuration;
using EAfspraak.Common;
using Microsoft.Extensions.Configuration;
using EAfspraak.DataLayer.Services;
using EAfspraak.DataLayer.Contracts;

var builder = WebApplication.CreateBuilder(args);


//var _FileConnectionStrings = .Get<FileConnectionStrings>().;
//builder.Services.Configure<FileConnectionStrings>(builder.Configuration.GetSection("FileConnectionStrings"));

var fileConnectionStrings = builder.Configuration.GetSection("FileConnectionStrings").Get<FileConnectionStrings>();
//FileConnectionStrings.EAfspraakFilePath= fileConnectionStrings.
builder.Services.AddScoped<IBehandelingService, BehandelingService>();


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
