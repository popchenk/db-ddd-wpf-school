using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Models
{
    public class Account
    {

        public AccountID accountID { get; }

        public string email { get; }

        public decimal money { get; }


        public Account(AccountID accountID, string email, decimal money)
        {
            this.accountID = accountID;
            this.email = email;
            this.money = money;
        }

        internal bool alreadyCreated(Account account)
        {
            if (account.accountID.ToString().Equals(this.accountID.ToString()))
            {
                return true;
            }
            return false;
        }

    }
}
