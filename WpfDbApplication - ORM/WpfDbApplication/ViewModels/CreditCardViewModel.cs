using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDbApplication.Commands;
using WpfDbApplication.Model;
using WpfDbApplication.Services;

namespace WpfDbApplication.ViewModels
{
    public class CreditCardViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AccountViewModel> accounts;
        public IEnumerable<AccountViewModel> accountsEnc => accounts;

        public ICommand CreditCardCommand { get; }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public ICommand LoadAccountsCommand { get; }
        
        AccountViewModel account;
        public AccountViewModel accountProperty
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged(nameof(accountProperty));
            }
        }

        string accountNumber;
        public string accountNumberBinding
        {

            get { return accountNumber; }
            set
            {
                accountNumber = value;
                OnPropertyChanged(nameof(accountNumberBinding));
            }

        }

        decimal moneyToSend;
        public decimal moneyToSendBinding
        {

            get { return moneyToSend; }
            set
            {
                moneyToSend = value;
                OnPropertyChanged(nameof(moneyToSendBinding));
            }

        }

        public string param;

        public CreditCardViewModel(Bank bank, NavigationService loadAccountNavigationService)
        {

            this.param = loadAccountNavigationService.param;
            accounts = new ObservableCollection<AccountViewModel>();
            LoadAccountsCommand = new NavigateCommand(loadAccountNavigationService);
            CreditCardCommand = new CreditCardCommand(this, bank);
            CreditCardCommand.Execute(null);
            SubmitCommand = new SendMoneyCommand(this, bank, loadAccountNavigationService);
            CancelCommand = new NavigateCommand(loadAccountNavigationService);
            //this.CreditCardCommand.Execute("5bc44ebd-f65f-4c2b-b791-946742f00b52");
        }




        public void UpdateAccount(Account account)
        {
           
                this.accounts.Clear();

                accountProperty = new AccountViewModel(account);
                this.accounts.Add(accountProperty);
            

        }

    }
}
