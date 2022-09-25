using System.Configuration;

//using Microsoft.Extensions.WebEncoders;
using Microsoft.Extensions.Configuration;
using EAfspraak.DataLayer.Services;
using EAfspraak.DataLayer.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBehandelingService, BehandelingService>();




// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

//string contentRoot = app.Services.GetService<IHostingEnvironment>()
//                             .ContentRootPath;
//FileConnectionStrings.EAfspraakFilePath = @contentRoot+@"Data\Data.txt";


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

