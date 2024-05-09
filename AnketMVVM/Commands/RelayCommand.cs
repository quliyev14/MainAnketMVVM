
using System.Windows.Input;

namespace AnketMVVM.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object?>? _execute;
        private readonly Predicate<object?>? _CanExecute;

        public RelayCommand(Action<object?>? execute, Predicate<object?>? canExecut = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecut;
        }

        public bool CanExecute(object? parameter) => _CanExecute is null || _CanExecute.Invoke(parameter);

        public void Execute(object? parameter) => _execute!.Invoke(parameter);
        
    }
}
