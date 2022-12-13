﻿using EAfspraak.Services.Interfaces;
using EAfspraak.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAfspraak.Services.Models
{
    public class AccountModel
    {
        private List<AccountViewModel> accounts;
        private IAfspraakService iAfspraakService;
        public AccountModel(IAfspraakService _iAfspraakService)
        {
            this.iAfspraakService = _iAfspraakService;
            accounts = new List<AccountViewModel>();
            //accounts.Add(new AccountViewModel("123",
            //"123",
            //new string[] { "admin" }));
           
            foreach (var item in iAfspraakService.GetPatienten())
            {
                accounts.Add(new AccountViewModel(item.BSN.ToString(), item.Birthday.ToShortDateString(), new string[] { "patient" }));
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
