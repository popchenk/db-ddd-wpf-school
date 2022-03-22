using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Exceptions;
using WpfDbApplication.Facade;
using WpfDbApplication.Services.Helpers;

namespace WpfDbApplication.Model
{
    //holds all the accounts
    public class AccountList
    {

        private readonly AccountFacade accountFacade; 

        public AccountList(AccountFacade accountFacade)
        {
            this.accountFacade = accountFacade;
        }

        //public IEnumerable<Account> GetBankAccountsForUser(string email)
        //{
            //return bankAccounts.Where(r => r.email == email);
        //    return null;
        //}

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountFacade.GetAll();
        }

        public async Task<Account> GetAccountByUuid(string uuid)
        {
            return await accountFacade.GetByUuid(uuid);
        }

        public async Task createAccount(Account account)
        {

            //Account conflictingAccount = await accountConflictValidator.GetConflictingAccount(account);

            //if(conflictingAccount != null)
            //{
            //    throw new AccountAlreadyExistsException(conflictingAccount, account);

            //}

        await accountFacade.Save(account);

        }


        public async Task sendMoneyToAccount(string uuid, decimal money)
        {
            await accountFacade.Update(uuid, money);

        }

    }
}
