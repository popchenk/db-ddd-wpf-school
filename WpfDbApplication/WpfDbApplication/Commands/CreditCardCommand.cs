using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfDbApplication.Model;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Commands
{
    public class CreditCardCommand : AsyncCommandBase
    {
        private readonly CreditCardViewModel creditCardViewModel;

        private readonly Bank bank;

        public CreditCardCommand(CreditCardViewModel creditCardViewModel, Bank bank)
        {
            this.creditCardViewModel = creditCardViewModel;
            this.bank = bank;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {

                Account account = await bank.GetAccountByUuid(creditCardViewModel.param);

                creditCardViewModel.UpdateAccount(account);

            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to load accounts." + e.Message + bank, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
