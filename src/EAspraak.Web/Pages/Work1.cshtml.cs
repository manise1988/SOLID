using EAfspraak.Services.Domain;
using EAfspraak.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "admin")]
    public class Work1Model : PageModel
    {
        public string UserId;
        public List<Category> Categories;
        [BindProperty]
        public string BehandelingName { get; set; }
        private readonly IAfspraakService iAfspraakService;

        public Work1Model(IAfspraakService iAfspraakService)
        {
            this.iAfspraakService = iAfspraakService;
            
            Categories = iAfspraakService.GetCategories();
        }
        public IActionResult OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
            return Page();
        }
        public IActionResult OnPostZoek()
        {
            var name = BehandelingName;
            
            return Page();
        }
    }
}
