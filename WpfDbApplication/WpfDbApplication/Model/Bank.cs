using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Model
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


        public IEnumerable<Account> GetBankAccountsForUser(string email)
        {
            return accountList.GetBankAccountsForUser(email);
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
