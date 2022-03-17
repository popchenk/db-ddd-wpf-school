using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDbApplication.Model;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Commands
{
    class LoadAccountsCommand : AsyncCommandBase
    {
        private readonly ListAccountsViewModel loadViewModel;
        private readonly Bank bank;

        public LoadAccountsCommand(ListAccountsViewModel loadViewModel, Bank bank)
        {
            this.loadViewModel = loadViewModel;
            this.bank = bank;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Account> accounts = await bank.GetAllAccounts();

                loadViewModel.UpdateAccounts(accounts);

            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to load accounts."+e.Message+bank.GetAllAccounts(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
