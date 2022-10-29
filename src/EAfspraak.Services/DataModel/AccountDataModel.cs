using EAfspraak.Services.Services.Interfases;
using EAfspraak.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.DataModel
{
    public class AccountDataModel
    {
        private List<AccountViewModel> accounts;
        private IAfspraakService iAfspraakService;
        public AccountDataModel(IAfspraakService _iAfspraakService)
        {
            this.iAfspraakService = _iAfspraakService;
            accounts = new List<AccountViewModel>();
            //accounts.Add(new AccountViewModel("123",
            //"123",
            //new string[] { "admin", "huisarts", "patient" }));
            foreach (var item in iAfspraakService.GetHuisartsen())
            {
                accounts.Add(new AccountViewModel(item.BSN.ToString(), item.Birthday, new string[] { "huisarts" }));
            }
            foreach (var item in iAfspraakService.GetPatienten())
            {
                accounts.Add(new AccountViewModel(item.BSN.ToString(), item.Birthday, new string[] { "patient" }));
            }

        }
        public AccountViewModel find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }
        public AccountViewModel login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }
    }
}
