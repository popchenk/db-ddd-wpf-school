using School_Stage_0.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Commands
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
