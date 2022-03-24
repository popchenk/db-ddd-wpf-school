using School_Stage_0.Stores;
using School_Stage_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Services
{
    public class NavigationService
    {

        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }
        public void Navigate()
        {
            navigationStore.currentViewModelBinding = createViewModel();
        }

    }
}
