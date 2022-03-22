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
using WpfDbApplication.Repository;
using WpfDbApplication.Facade;

namespace WpfDbApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //move to cfg file
        private const string CONNECTION_STRING = "Data Source=bank.db";
        private readonly Bank bank;

        private readonly NavigationStore navigationStore;

        private readonly IUnitOfWork uof;

        private readonly AccountFacade accountFacade;

        private readonly IAccountRepository accountRepository;

        private readonly ICardRepository cardRepository;

        public App()
        {
            uof = new UnitOfWork(new DatabaseContextFactory());
            accountRepository = new AccountRepository(uof);
            cardRepository = new CardRepository(uof);
            accountFacade = new AccountFacade(accountRepository, cardRepository, uof);
            AccountList accountList = new AccountList(accountFacade);

            this.bank = new Bank("KB", accountList);
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
            return ListAccountsViewModel.LoadViewModel(bank, new NavigationService(navigationStore, CreateMakeAccountViewModel), new NavigationService(navigationStore, CreateCreditCardViewModel));
        }

        private CreditCardViewModel CreateCreditCardViewModel()
        {
            return new CreditCardViewModel(bank, new NavigationService(navigationStore, CreateAccountViewModel));
        }


    }
}
