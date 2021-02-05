using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace watchdogmanager.blazor.Components.Organizations
{
    public class GenericCommand : ICommand
    {
        private readonly Func<string,Task> _action;

        public event EventHandler CanExecuteChanged;

        public GenericCommand(Func<string, Task> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var input = parameter as string;

            var task = _action(input);
            Task.WhenAll(task);
        }
    }
}
