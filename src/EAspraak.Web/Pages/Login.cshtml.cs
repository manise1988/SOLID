using EAfspraak.Services.Models;
using EAfspraak.Services.Interfaces;


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAfspraak.Web.Pages
{
    public class LoginModel : PageModel
    {
        public string message;
        private IAfspraakService iAfspraakService;

        private ISecurityService securityManager;

        public LoginModel(IAfspraakService afspraakService,ISecurityService securityService)
        {
            this.iAfspraakService = afspraakService;
            this.securityManager = securityService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostLogin(string username, string password)
        {
            AccountModel accountModel = new AccountModel(iAfspraakService);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || accountModel.login(username, password) == null)
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

        //    public IActionResult OnPost(string username, string password)
        //{
        //    AccountModel accountModel = new AccountModel();
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || accountModel.login(username, password) == null)
        //    {
        //        Msg = "Invalid";
        //        return Page();
        //    }
        //    else
        //    {
        //        securityManager.SignIn(HttpContext, accountModel.find(username));
        //        return RedirectToPage("Welcome");
        //    }
        //}
    }
}
