using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Exceptions;
using WpfDbApplication.Services.AccountCreators;
using WpfDbApplication.Services.AccountProviders;
using WpfDbApplication.Services.AccountConflictValidators;

namespace WpfDbApplication.Model
{
    //holds all the accounts
    public class AccountList
    {

        private readonly IAccountProvider accountProvider;
        private readonly IAccountCreator accountCreator;
        private readonly IAccountConflictValidator accountConflictValidator;

        public AccountList(IAccountProvider accountProvider, IAccountCreator accountCreator, IAccountConflictValidator accountConflictValidator)
        {
            this.accountProvider = accountProvider;
            this.accountCreator = accountCreator;
            this.accountConflictValidator = accountConflictValidator;
        }

        //public IEnumerable<Account> GetBankAccountsForUser(string email)
        //{
            //return bankAccounts.Where(r => r.email == email);
        //    return null;
        //}

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await accountProvider.GetAllAccounts();
        }

        public async Task createAccount(Account account)
        {

            Account conflictingAccount = await accountConflictValidator.GetConflictingAccount(account);

            if(conflictingAccount != null)
            {
                throw new AccountAlreadyExistsException(conflictingAccount, account);

            }

            await accountCreator.CreateAccount(account);

        }

    }
}
