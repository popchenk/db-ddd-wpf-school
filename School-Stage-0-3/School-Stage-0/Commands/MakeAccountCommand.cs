using School_Stage_0.Exceptions;
using School_Stage_0.Models;
using School_Stage_0.Services;
using School_Stage_0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace School_Stage_0.Commands
{
    public class MakeAccountCommand : AsyncCommandBase
    {

        private readonly Bank bank;

        private readonly MakeAccountViewModel makeAccountViewModel;

        private readonly NavigationService accountViewNavigationService;

        public MakeAccountCommand(Bank bank, MakeAccountViewModel makeAccountViewModel,
            NavigationService accountViewNavigationService)
        {
            this.bank = bank;
            this.makeAccountViewModel = makeAccountViewModel;
            this.accountViewNavigationService = accountViewNavigationService;
            makeAccountViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeAccountViewModel.emailBinding) ||
                e.PropertyName == nameof(MakeAccountViewModel.startMoneyBinding) ||
                e.PropertyName == nameof(MakeAccountViewModel.nationalityBinding))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {

            Account account = new Account(
                new AccountID(makeAccountViewModel.nationalityBinding),
                makeAccountViewModel.emailBinding,
                makeAccountViewModel.startMoneyBinding
                );

            try
            {
                await bank.createAccount(account);
                MessageBox.Show("Account added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                accountViewNavigationService.Navigate();

            }
            catch (AccountAlreadyExistsException exception)
            {
                MessageBox.Show("This account ID is already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(makeAccountViewModel.emailBinding) &&
                makeAccountViewModel.startMoneyBinding > 1000 &&
                !string.IsNullOrEmpty(makeAccountViewModel.nationalityBinding) &&
                base.CanExecute(parameter);
        }

    }
}
