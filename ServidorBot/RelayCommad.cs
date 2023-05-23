using System;
using System.Windows.Input;

namespace ServidorBot
{
    public class RelayCommand : ICommand
    {

        private readonly Action<Object> _execute;
        private readonly Predicate<Object> _canExucute;


        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }
        public RelayCommand(Action<object> execute, Predicate<object> canExucute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExucute = canExucute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExucute == null ? true : _canExucute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
