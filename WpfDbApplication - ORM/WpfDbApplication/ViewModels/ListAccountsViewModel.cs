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

        //observable collection so it gets instantly updated in the view
        private readonly ObservableCollection<AccountViewModel> accounts;

        public ICommand MakeAccountCommand { get; }
        public ICommand CreditCardCommand { get; }

        public ICommand LoadAccountsCommand { get; }

        // we dont need the whole observable collection so lets encapsulate it into ienumerable
        public IEnumerable<AccountViewModel> accountsEnc => accounts;

        public ListAccountsViewModel(Bank bank, NavigationService makeAccountNavigationService, NavigationService creditCardNavigationService)
        {

            accounts = new ObservableCollection<AccountViewModel>();

            MakeAccountCommand = new NavigateCommand(makeAccountNavigationService);
            CreditCardCommand = new NavigateCommand(creditCardNavigationService);
            LoadAccountsCommand = new LoadAccountsCommand(this, bank);


        }

        public static ListAccountsViewModel LoadViewModel(Bank bank, NavigationService makeAccountNavigationService, NavigationService creditCardNavigationService)
        {
            ListAccountsViewModel viewModel = new ListAccountsViewModel(bank, makeAccountNavigationService, creditCardNavigationService);

            viewModel.LoadAccountsCommand.Execute(null);

            return viewModel;
        }

        public void UpdateAccounts(IEnumerable<Account> accounts)
        {
            this.accounts.Clear();

            foreach(Account account in accounts)
            {
                AccountViewModel accountViewModel = new AccountViewModel(account);
                this.accounts.Add(accountViewModel);
            }

        }
    }
}
