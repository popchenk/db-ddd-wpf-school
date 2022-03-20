using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.ViewModels;

namespace WpfDbApplication.Stores
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

        private string passingParameter;

        public string passingParameterBinding
        {
            get => passingParameter;
            set
            {
                passingParameter = value;
            }
        }

        public event Action currentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            currentViewModelChanged?.Invoke();
        }

    }
}
