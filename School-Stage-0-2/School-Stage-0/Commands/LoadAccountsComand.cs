using School_Stage_0.Models;
using School_Stage_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace School_Stage_0.Commands
{
    public class LoadAccountsCommand : AsyncCommandBase
    {
        private readonly ListAccountViewModel loadViewModel;
        private readonly Bank bank;

        public LoadAccountsCommand(ListAccountViewModel loadViewModel, Bank bank)
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
                MessageBox.Show("Failed to load accounts." + e.Message + bank.GetAllAccounts(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
