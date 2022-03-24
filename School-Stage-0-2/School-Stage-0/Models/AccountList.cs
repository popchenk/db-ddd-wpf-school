using School_Stage_0.Exceptions;
using School_Stage_0.Facade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School_Stage_0.Models
{
    public class AccountList
    {

        private readonly List<Account> bankAccounts;

        AccountFacade accountFacade;

        public AccountList(AccountFacade accountFacade)
        {
            bankAccounts = new List<Account>();
            this.accountFacade = accountFacade;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountFacade.GetAll();
        }

        public async Task createAccount(Account account)
        {
            await accountFacade.Save(account);

        }

    }
}
