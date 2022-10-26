using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.ViewModels
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public Account(string username, string password, string[] roles)
        {
            Username = username;
            Password = password;
            Roles = roles;
        }
    }
}
