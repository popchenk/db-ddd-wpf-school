using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool isExecuting;


        private bool isExecutingBinding
        {
            get
            {
                return isExecuting;
            }
            set
            {
                isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !isExecutingBinding && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {

            isExecutingBinding = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                isExecutingBinding = true;
            }

        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
