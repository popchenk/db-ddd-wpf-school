using School_Stage_0.Models;
using School_Stage_0.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public ViewModelBase CurrentViewModel => navigationStore.currentViewModelBinding;

        private readonly NavigationStore navigationStore;

        public MainViewModel(Bank bank, NavigationStore navigationStore)
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
