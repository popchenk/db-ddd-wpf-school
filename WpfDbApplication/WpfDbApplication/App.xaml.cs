using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfDbApplication.DbContexts;
using WpfDbApplication.Exceptions;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.Stores;
using WpfDbApplication.ViewModels;
using WpfDbApplication.Services.AccountProviders;
using WpfDbApplication.Services.AccountCreators;
using WpfDbApplication.Services.AccountConflictValidators;
using WpfDbApplication.Services.AccountUpdaters;

namespace WpfDbApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //move to cfg file
        private const string CONNECTION_STRING = "server=wpf-db.c69xzkzvbddr.us-east-1.rds.amazonaws.com;database=BankSystem;user id=admin;password=7dLjMaYjdaPmhDd6EodO";
        private readonly Bank bank;

        private readonly NavigationStore navigationStore;

        private readonly BankSystemContextFactory bankSystemContextFactory;

        public App()
        {
            bankSystemContextFactory = new BankSystemContextFactory(CONNECTION_STRING);
            IAccountProvider accountProvider = new DatabaseAccountProvider(bankSystemContextFactory);
            IAccountCreator accountCreator = new DatabaseAccountCreator(bankSystemContextFactory);
            IAccountConflictValidator accountConflictValidator = new DatabaseAccountConflictValidator(bankSystemContextFactory);
            IAccountUpdater accountUpdater = new DatabaseAccountUpdater(bankSystemContextFactory);
            AccountList accountList = new AccountList(accountProvider, accountCreator, accountConflictValidator, accountUpdater);

            this.bank = new Bank("KB", accountList);
            this.navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (BankSystemContext dbContext = new BankSystemContext())
            {
                dbContext.Database.Migrate();
            }



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
            return ListAccountsViewModel.LoadViewModel(bank, new NavigationService(navigationStore, CreateMakeAccountViewModel), new NavigationService(navigationStore, CreateCreditCardViewModel));
        }

        private CreditCardViewModel CreateCreditCardViewModel()
        {
            return new CreditCardViewModel(bank, new NavigationService(navigationStore, CreateAccountViewModel));
        }


    }
}
