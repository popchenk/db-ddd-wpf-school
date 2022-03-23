using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;

namespace WpfDbApplication.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {

        private readonly Account account;

        // no logic needed -> make accountID string
        public string accountID => account.accountID?.ToString();
        public string email => account.email;
        public decimal money => account.money;
        public Card card => account.card;

        public AccountViewModel(Account account)
        {
            this.account = account;
        }

    }
}
