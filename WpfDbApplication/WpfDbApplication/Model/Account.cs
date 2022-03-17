using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Model
{
    public class Account
    {

        private readonly Card accountCard;

        // accountID can change in the future
        public AccountID accountID { get; }

        public string email { get; }

        public decimal money { get; }


        public Account(AccountID accountID, string email, decimal money, Card card)
        {
            this.accountCard = card;
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
