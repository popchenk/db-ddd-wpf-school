using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Exceptions;

namespace WpfDbApplication.Model
{
    //holds all the accounts
    public class AccountList
    {

        private readonly List<Account> bankAccounts;

        public AccountList()
        {
            bankAccounts = new List<Account>();
        }

        public IEnumerable<Account> GetBankAccountsForUser(string email)
        {
            return bankAccounts.Where(r => r.email == email);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return bankAccounts;
        }

        public void createAccount(Account account)
        {
            foreach(Account existingAccount in GetBankAccountsForUser(account.email))
            {
                //just in case we get the same uuid generated (its not 100% unique)
                if (existingAccount.alreadyCreated(account))
                {
                    throw new AccountAlreadyExistsException(existingAccount, account);
                }
            }
            bankAccounts.Add(account);

        }

    }
}
