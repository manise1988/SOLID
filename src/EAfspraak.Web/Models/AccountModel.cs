
using EAfspraak.Web.Services;
using EAfspraak.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Web.Models
{
    public class AccountModel
    {
        private List<AccountViewModel> accounts;
        public AccountModel(AfspraakService afspraakService)
        {
           
            accounts = new List<AccountViewModel>();
            //accounts.Add(new AccountViewModel("123",
            //"123",
            //new string[] { "admin" }));

            foreach (var item in afspraakService.GetPatienten())
            {
                DateTime dateTime = DateTime.Parse(item.Birthday.ToString());
                accounts.Add(new AccountViewModel(item.BSN.ToString(), dateTime.ToShortDateString(), new string[] { "patient" }));
            }

        }
        public AccountViewModel find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }
        public AccountViewModel login(string username, string password)
        {
            //DateTime geboorteDatum = DateTime.Parse(password);
            //geboorteDatum.ToShortDateString()
            return accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
        }
    }
}
