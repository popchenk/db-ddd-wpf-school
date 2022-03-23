using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDbApplication.Commands;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.Stores;

namespace WpfDbApplication.ViewModels
{
    public class MakeAccountViewModel : ViewModelBase
    {

        private string email;

        public string emailBinding
        {

            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(emailBinding));
            }

        }


        private decimal money = 1000;

        public decimal startMoneyBinding
        {

            get { return money; }
            set
            {
                money = value;
                OnPropertyChanged(nameof(startMoneyBinding));
            }

        }

        private string nationality;

        public string nationalityBinding
        {

            get { return nationality; }
            set
            {
                nationality = value;
                OnPropertyChanged(nameof(nationalityBinding));
            }

        }

        private string cardNum;

        public string cardNumBinding
        {

            get { return cardNum; }
            set
            {
                cardNum = value;
                OnPropertyChanged(nameof(cardNumBinding));
            }

        }


        private int cvv;

        public int cvvBinding
        {

            get { return cvv; }
            set
            {
                cvv = value;
                OnPropertyChanged(nameof(cvvBinding));
            }

        }

        private string expDate;

        public string expDateBinding
        {

            get { return expDate; }
            set
            {
                expDate = value;
                OnPropertyChanged(nameof(expDateBinding));
            }

        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeAccountViewModel(Bank bank,
            NavigationService accountViewNavigationService)
        {
            SubmitCommand = new MakeAccountCommand(this, bank, accountViewNavigationService);

            CancelCommand = new NavigateCommand(accountViewNavigationService);
        }

    }
}
