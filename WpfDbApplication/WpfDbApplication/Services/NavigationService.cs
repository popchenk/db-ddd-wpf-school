using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Stores;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Services
{
    public class NavigationService
    {

        private readonly NavigationStore navigationStore;

        private readonly Func<ViewModelBase> createViewModel;

        public string param;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
            this.param = navigationStore.passingParameterBinding;
        }
        public void Navigate(object parameter = null)
        {
            if(parameter != null) navigationStore.passingParameterBinding = (string)parameter;

            navigationStore.currentViewModelBinding = createViewModel();
        }

    }
}
