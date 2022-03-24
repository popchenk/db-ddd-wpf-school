using School_Stage_0.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Models
{
    public class AccountList
    {

        private readonly List<Account> bankAccounts;

        public AccountList()
        {
            bankAccounts = new List<Account>();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return bankAccounts;
        }

        public void createAccount(Account account)
        {
            foreach (Account existingAccount in GetAllAccounts())
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
