using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Commands
{
    public class SendMoneyCommand : AsyncCommandBase
    {
        private readonly CreditCardViewModel creditCardViewModel;
        private readonly Bank bank;
        private readonly NavigationService AccountViewNavigationService;

        public SendMoneyCommand(CreditCardViewModel creditCardViewModel,
            Bank bank,
            NavigationService accountViewNavigationService
            )
        {
            this.creditCardViewModel = creditCardViewModel;
            this.bank = bank;
            AccountViewNavigationService = accountViewNavigationService;
            creditCardViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreditCardViewModel.accountNumberBinding) ||
                e.PropertyName == nameof(CreditCardViewModel.moneyToSendBinding))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                await bank.sendMoneyToAccount(creditCardViewModel.accountNumberBinding, creditCardViewModel.moneyToSendBinding);
                MessageBox.Show("Money added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                AccountViewNavigationService.Navigate();

            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to create account." + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(creditCardViewModel.accountNumberBinding) &&
                creditCardViewModel.moneyToSendBinding > 0 &&
                base.CanExecute(parameter);
        }

    }
}
