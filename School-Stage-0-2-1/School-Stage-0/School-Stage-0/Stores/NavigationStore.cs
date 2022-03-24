using School_Stage_0.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Stores
{
    public class NavigationStore
    {

        private ViewModelBase currentViewModel;

        public ViewModelBase currentViewModelBinding
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action currentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            currentViewModelChanged?.Invoke();
        }

    }
}
