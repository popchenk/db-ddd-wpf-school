using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfDbApplication.Exceptions;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.Stores;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Bank bank;

        private readonly NavigationStore navigationStore;

        public App()
        {
            this.bank = new Bank("KB");
            this.navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            navigationStore.currentViewModelBinding = CreateAccountViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);

        }

        private MakeAccountViewModel CreateMakeAccountViewModel()
        {
            return new MakeAccountViewModel(bank, new NavigationService(navigationStore, CreateAccountViewModel));
        }

        private ListAccountsViewModel CreateAccountViewModel()
        {
            return new ListAccountsViewModel(bank, new NavigationService(navigationStore, CreateMakeAccountViewModel));
        }

        private void tests()
        {
            Bank bank = new Bank("KB");

            try
            {

                bank.createAccount(new Account(new AccountID("CZ"), "michal.popcak@seznam.cz", 1000));

                bank.createAccount(new Account(new AccountID("DE"), "michal.popcak@seznam.cz", 5000));

            }
            catch (AccountAlreadyExistsException exception)
            {



            }



            IEnumerable<Account> accounts = bank.GetBankAccountsForUser("michal.popcak@seznam.cz");


        }

    }
}
