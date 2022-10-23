using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using EAfspraak.Web.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace EAfspraak.Web.Security
{
    public class SecurityManager
    {
        public async void SignIn(HttpContext httpContext ,Account account)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Username));
            identity.AddClaim(new Claim(ClaimTypes.Name,account.Username));
            identity.AddClaims(getUserClaims(account));
            var principal= new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
            
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> getUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));
            foreach (var role in account.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
