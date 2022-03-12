using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDbApplication.Exceptions;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Commands
{
    public class MakeAccountCommand : CommandBase
    {
        private readonly MakeAccountViewModel makeAccountViewModel;
        private readonly Bank bank;
        private readonly NavigationService AccountViewNavigationService;

        public MakeAccountCommand(MakeAccountViewModel makeAccountViewModel,
            Bank bank,
            NavigationService accountViewNavigationService
            )
        {
            this.makeAccountViewModel = makeAccountViewModel;
            this.bank = bank;
            AccountViewNavigationService = accountViewNavigationService;
            makeAccountViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if( e.PropertyName == nameof(MakeAccountViewModel.emailBinding) ||
                e.PropertyName == nameof(MakeAccountViewModel.startMoneyBinding) ||
                e.PropertyName == nameof(MakeAccountViewModel.nationalityBinding))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {

            Account account = new Account(
                new AccountID(makeAccountViewModel.nationalityBinding),
                makeAccountViewModel.emailBinding,
                makeAccountViewModel.startMoneyBinding
                );

            try
            {
                bank.createAccount(account);
                MessageBox.Show("Account added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                AccountViewNavigationService.Navigate();

            }
            catch( AccountAlreadyExistsException exception)
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
