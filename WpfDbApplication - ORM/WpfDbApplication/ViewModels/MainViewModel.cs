using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;
using WpfDbApplication.Stores;

namespace WpfDbApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly NavigationStore navigationStore;

        public ViewModelBase CurrentViewModel => navigationStore.currentViewModelBinding;

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;

            navigationStore.currentViewModelChanged += OnCurrentViewModelChanged;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
