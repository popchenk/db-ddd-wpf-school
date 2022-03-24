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
    class ListAccountViewModel : ViewModelBase
    {

        private readonly Bank bank;

        private readonly ObservableCollection<AccountViewModel> accounts;

        private readonly NavigationService navigationService;

        public ICommand MakeAccountCommand { get; }

        // we dont need the whole observable collection so lets encapsulate it into ienumerable
        public IEnumerable<AccountViewModel> accountsEnc => accounts;

        public ListAccountViewModel(Bank bank, NavigationService navigationService)
        {
            this.bank = bank;

            this.MakeAccountCommand = new NavigateCommand(navigationService);

            accounts = new ObservableCollection<AccountViewModel>();


            UpdateAccounts();

        }

        private void UpdateAccounts()
        {
            accounts.Clear();

            foreach (Account account in bank.GetAllAccounts())
            {
                AccountViewModel accountViewModel = new AccountViewModel(account);
                accounts.Add(accountViewModel);
            }

        }

    }
}
