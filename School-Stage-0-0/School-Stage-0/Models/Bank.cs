using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Models
{
    public class Bank
    {

        private readonly AccountList accountList;

        public string name { get; }

        public Bank(string name)
        {

            this.name = name;

            accountList = new AccountList();

        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountList.GetAllAccounts();
        }

        public void createAccount(Account account)
        {
            accountList.createAccount(account);
        }

    }
}
