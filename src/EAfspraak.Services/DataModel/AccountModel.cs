using EAfspraak.Services.Services.Interfases;
using EAfspraak.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.DataModel
{
    public class AccountModel
    {
        private List<Account> accounts;
        private IAfspraakService iAfspraakService;
        public AccountModel(IAfspraakService _iAfspraakService)
        {
            this.iAfspraakService = _iAfspraakService;
            accounts = new List<Account>();
            accounts.Add(new Account("admin",
            "123",
            new string[] { "admin", "huisarts", "patient" }));
            foreach (var item in iAfspraakService.GetHuisartsen())
            {
                accounts.Add(new Account(item.BSN.ToString(), item.Birthday, new string[] { "huisarts" }));
            }
            foreach (var item in iAfspraakService.GetPatienten())
            {
                accounts.Add(new Account(item.BSN.ToString(), item.Birthday, new string[] { "patient" }));
            }

        }
        public Account find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }
        public Account login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }
    }
}
