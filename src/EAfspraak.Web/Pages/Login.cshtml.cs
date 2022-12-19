using EAfspraak.Web.Models;
using EAfspraak.Web.Services;


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAfspraak.Web.Pages
{
    public class LoginModel : PageModel
    {
        public string message;
        private AfspraakService afspraakService;

        private SecurityService securityManager;

        public LoginModel()
        {
            this.afspraakService = new AfspraakService();
            this.securityManager = new SecurityService();
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostLogin(string username, string password)
        {
            AccountModel accountModel = new AccountModel(afspraakService);
            DateTime geboorteDatum = DateTime.Parse(password);


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(geboorteDatum.ToShortDateString()) || accountModel.login(username, geboorteDatum.ToShortDateString()) == null)
            {
                message = "Invalid";
                return Page();
            }
            else
            {
                securityManager.SignIn(HttpContext, accountModel.find(username));
                return RedirectToPage("Index");
            }
        }


    }
}
