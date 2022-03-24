using School_Stage_0.DbContexts;
using School_Stage_0.Facade;
using School_Stage_0.Models;
using School_Stage_0.Repository;
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

        private readonly IUnitOfWork uof;

        private readonly AccountFacade accountFacade;

        private readonly IAccountRepository accountRepository;

        public App()
        {
            uof = new UnitOfWork(new DatabaseContextFactory());
            accountRepository = new AccountRepository(uof);
            accountFacade = new AccountFacade(accountRepository, uof);
            AccountList accountList = new AccountList(accountFacade);

            this.bank = new Bank("KB", accountList);
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
            return ListAccountViewModel.LoadViewModel(bank, new NavigationService(navigationStore, CreateMakeAccountViewModel));
        }

    }
}
