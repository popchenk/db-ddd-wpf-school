using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Exceptions;
using WpfDbApplication.Services.AccountCreators;
using WpfDbApplication.Services.AccountProviders;
using WpfDbApplication.Services.AccountConflictValidators;
using WpfDbApplication.Services.AccountUpdaters;

namespace WpfDbApplication.Model
{
    //holds all the accounts
    public class AccountList
    {

        private readonly IAccountProvider accountProvider;
        private readonly IAccountCreator accountCreator;
        private readonly IAccountConflictValidator accountConflictValidator;
        private readonly IAccountUpdater accountUpdater;

        public AccountList(IAccountProvider accountProvider, IAccountCreator accountCreator, IAccountConflictValidator accountConflictValidator, IAccountUpdater accountUpdater)
        {
            this.accountProvider = accountProvider;
            this.accountCreator = accountCreator;
            this.accountConflictValidator = accountConflictValidator;
            this.accountUpdater = accountUpdater;
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

        public async Task<Account> GetAccountByUuid(string uuid)
        {
            return await accountProvider.GetAccountByUuid(uuid);
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

        public async Task sendMoneyToAccount(string uuid, decimal money)
        {

           await accountUpdater.UpdateAccountMoney(uuid, money);

        }

    }
}
