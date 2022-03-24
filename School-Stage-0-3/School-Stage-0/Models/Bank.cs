using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School_Stage_0.Models
{
    public class Bank
    {

        private readonly AccountList accountList;

        public string name { get; }

        public Bank(string name, AccountList accountList)
        {

            this.name = name;

            this.accountList = accountList;

        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountList.GetAllAccounts();
        }

        public async Task createAccount(Account account)
        {
            accountList.createAccount(account);
        }

    }
}
