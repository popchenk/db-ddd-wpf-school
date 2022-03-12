using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDbApplication.Commands;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.Stores;

namespace WpfDbApplication.ViewModels
{
    public class ListAccountsViewModel : ViewModelBase
    {
        private readonly Bank bank;

        private readonly ObservableCollection<AccountViewModel> accounts;

        public ICommand MakeAccountCommand { get; }

        // we dont need the whole observable collection so lets encapsulate it into ienumerable
        public IEnumerable<AccountViewModel> accountsEnc => accounts;

        public ListAccountsViewModel(Bank bank, NavigationService makeAccountNavigationService)
        {
            this.bank = bank;

            accounts = new ObservableCollection<AccountViewModel>();

            MakeAccountCommand = new NavigateCommand(makeAccountNavigationService);

            UpdateReservations();

        }

        private void UpdateReservations()
        {
            accounts.Clear();

            foreach(Account account in bank.GetAllAccounts())
            {
                AccountViewModel accountViewModel = new AccountViewModel(account);
                accounts.Add(accountViewModel);
            }

        }
    }
}
