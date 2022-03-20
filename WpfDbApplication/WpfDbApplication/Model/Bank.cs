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

        public Bank(string name, AccountList accountList)
        {

            this.name = name;

            this.accountList = accountList;

        }


        //public IEnumerable<Account> GetBankAccountsForUser(string email)
        //{
        //    return accountList.GetBankAccountsForUser(email);
        //}

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountList.GetAllAccounts();
        }

        public async Task<Account> GetAccountByUuid(string uuid)
        {
            return await accountList.GetAccountByUuid(uuid);
        }

        public async Task createAccount(Account account)
        {
            await accountList.createAccount(account);
        }

        public async Task sendMoneyToAccount(string uuid, decimal money)
        {
            await accountList.sendMoneyToAccount(uuid, money);
        }

    }
}
