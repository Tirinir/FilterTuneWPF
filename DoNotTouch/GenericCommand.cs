using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;

namespace FilterTuneWPF
{
    class GenericCommand : ICommand
    {
        private Action<object> storedCommand;
        private Func<bool> canExecute;

        public GenericCommand(Action<object> command)
        {
            storedCommand = command;
        }

        public GenericCommand(Action<object> command, Func<bool> canExecute)
        {
            storedCommand = command;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        public void Execute(object parameter) => storedCommand?.Invoke(parameter);
        public bool CanExecute(object parameter) => canExecute?.Invoke() ?? true;
    }
}