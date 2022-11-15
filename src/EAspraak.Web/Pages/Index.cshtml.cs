using EAfspraak.Services.Interfaces;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Claims;

namespace EAfspraak.Web.Pages
{
    [Authorize(Roles = "admin,huisarts,patient")]
    public class IndexModel : PageModel
    {
        //private IAfspraakService _IAfspraakService;
        public string UserId;
        public string Role="patient";
        private ISecurityService securityManager;

        public IndexModel(ISecurityService securityManager)//IAfspraakService iAfspraakService)
        {
           // _IAfspraakService = iAfspraakService;
           this.securityManager = securityManager;

        }
        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
            Role = User.FindFirst(ClaimTypes.Name).Subject.Claims.ElementAt(3).Value;
         

        }
        public IActionResult OnGetLogout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToPage("Login");
        }
     

    }
}
