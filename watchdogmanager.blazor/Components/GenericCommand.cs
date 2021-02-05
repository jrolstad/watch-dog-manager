using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace watchdogmanager.blazor.Components.Organizations
{
    public class GenericCommand<T> : ICommand
    {
        private readonly Func<T,Task> _action;

        public event EventHandler CanExecuteChanged;

        public GenericCommand(Func<T, Task> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var input = (T)parameter;

            var task = _action(input);
            Task.WhenAll(task);
        }
    }
}
