using EAfspraak.Web.Models;
using EAfspraak.Web.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAfspraak.Web.Pages
{
    public class LoginModel : PageModel
    {
        public string message;

        private SecurityManager securityManager = new SecurityManager();

        public void OnGet()
        {
        }
        public IActionResult OnPostLogin(string username, string password)
        {
            AccountModel accountModel = new AccountModel();
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
