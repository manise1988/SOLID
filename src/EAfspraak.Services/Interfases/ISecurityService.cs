using EAfspraak.Services.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Interfases
{
    using EAfspraak.Services.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;

    using System.Collections.Generic;
    using System.Security.Claims;
    public interface ISecurityService
    {
        public void SignIn(HttpContext httpContext, AccountViewModel account);

        public void SignOut(HttpContext httpContext);

    }
}
