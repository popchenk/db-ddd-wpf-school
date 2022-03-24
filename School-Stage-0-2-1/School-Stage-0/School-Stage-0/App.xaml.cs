using School_Stage_0.Models;
using School_Stage_0.Services;
using School_Stage_0.Stores;
using School_Stage_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace School_Stage_0
{


    public partial class App : Application
    {

        Bank bank;

        NavigationStore navigationStore;

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
                DataContext = new MainViewModel(bank, navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);

        }

        private MakeAccountViewModel CreateMakeAccountViewModel()
        {
            return new MakeAccountViewModel(bank, new NavigationService(navigationStore, CreateAccountViewModel));
        }

        private ListAccountViewModel CreateAccountViewModel()
        {
            return new ListAccountViewModel(bank, new NavigationService(navigationStore, CreateMakeAccountViewModel));
        }


        void tests()
        {
            
            Account account = new Account(new AccountID("CZ"), "popchenk@gmail.com", 1000);
            Account account2 = new Account(new AccountID("CZ"), "popchenk2@gmail.com", 1000);
            Account account3 = new Account(new AccountID("CZ"), "popchenk3@gmail.com", 1000);
            bank.createAccount(account);
            bank.createAccount(account2);
            bank.createAccount(account3);
        }
    }
}
