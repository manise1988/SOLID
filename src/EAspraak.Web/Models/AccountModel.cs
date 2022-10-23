using EAfspraak.Web.Entities;

namespace EAfspraak.Web.Models
{
    public class AccountModel
    {
        private List<Account> accounts;
     public AccountModel()
        {
            accounts = new List<Account>()
            {
                new Account
                {
                Username="acc1",
                Password="123",
                Roles = new string[] { "admin","huisarts","patient" }
                },
                new Account
                {
                    Username="acc2",
                    Password = "123",
                    Roles = new string[] { "huisarts" }
                },
                 new Account
                {
                    Username="acc3",
                    Password = "123",
                    Roles = new string[] { "patient" }
                }
            };

        }
        public Account find(string username)
        {
            return accounts.SingleOrDefault(a => a.Username.Equals(username));
        }
        public Account login(string username,string password)
        {
            return accounts.SingleOrDefault(a=> a.Username.Equals(username) && a.Password.Equals(password));
        }
    }
}
