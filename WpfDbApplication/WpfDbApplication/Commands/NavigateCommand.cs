using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;
using WpfDbApplication.Services;
using WpfDbApplication.Stores;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService navigationService;
        public NavigateCommand(NavigationService navigationService)
        {

            this.navigationService = navigationService;

        }


        public override void Execute(object parameter)
        {
            navigationService.Navigate();
        }
    }
}
