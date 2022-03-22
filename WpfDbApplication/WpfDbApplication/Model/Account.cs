using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Model
{
    public class Account
    {

        public Card card;

        // accountID can change in the future
        public AccountID accountID { get; }

        public string email { get; }

        public decimal money { get; set; }


        public Account(AccountID accountID, string email, decimal money, Card card)
        {
            this.card = card;
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
