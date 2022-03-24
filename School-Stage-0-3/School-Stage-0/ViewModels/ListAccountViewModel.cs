using School_Stage_0.Commands;
using School_Stage_0.Models;
using School_Stage_0.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace School_Stage_0.ViewModels
{
    public class ListAccountViewModel : ViewModelBase
    {

        private readonly Bank bank;

        private readonly ObservableCollection<AccountViewModel> accounts;

        private readonly NavigationService navigationService;

        public ICommand MakeAccountCommand { get; }
        public ICommand LoadAccountsCommand { get; }

        // we dont need the whole observable collection so lets encapsulate it into ienumerable
        public IEnumerable<AccountViewModel> accountsEnc => accounts;

        public ListAccountViewModel(Bank bank, NavigationService navigationService)
        {
            this.bank = bank;

            this.MakeAccountCommand = new NavigateCommand(navigationService);
            this.LoadAccountsCommand = new LoadAccountsCommand(this, bank);

            accounts = new ObservableCollection<AccountViewModel>();



        }

        public static ListAccountViewModel LoadViewModel(Bank bank, NavigationService makeAccountNavigationService)
        {
            ListAccountViewModel viewModel = new ListAccountViewModel(bank, makeAccountNavigationService);

            viewModel.LoadAccountsCommand.Execute(null);

            return viewModel;
        }

        public void UpdateAccounts(IEnumerable<Account> accounts)
        {
            this.accounts.Clear();

            foreach (Account account in accounts)
            {
                AccountViewModel accountViewModel = new AccountViewModel(account);
                this.accounts.Add(accountViewModel);
            }

        }

    }
}
