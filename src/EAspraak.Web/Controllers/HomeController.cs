
using EAfspraak.DataLayer.Contracts;
using EAfspraak.DataLayer.Services;
using EAspraak.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EAspraak.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBehandelingService _behandelingService;
        public HomeController(ILogger<HomeController> logger, IBehandelingService behandelingService)
        {
            _logger = logger;
            _behandelingService = behandelingService;   
        }

        public IActionResult Index()
        {
           
            _behandelingService.getData();
            return View();
        }

        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}