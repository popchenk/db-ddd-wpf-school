using School_Stage_0.Commands;
using School_Stage_0.Models;
using School_Stage_0.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace School_Stage_0.ViewModels
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeAccountViewModel(Bank bank, NavigationService navigationService)
        {

            this.SubmitCommand = new MakeAccountCommand(bank, this, navigationService);
            this.CancelCommand = new NavigateCommand(navigationService);
        }

    }
}
