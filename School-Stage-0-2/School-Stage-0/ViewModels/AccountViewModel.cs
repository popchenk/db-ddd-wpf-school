using School_Stage_0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {

        private readonly Account account;

        // no logic needed -> make accountID string
        public string accountID => account.accountID?.ToString();
        public string email => account.email;
        public decimal money => account.money;

        public AccountViewModel(Account account)
        {
            this.account = account;
        }

    }
}
