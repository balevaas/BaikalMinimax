using System.Windows.Input;

namespace ViewModelBase.Commands.QuickCommand
{
    public class Command<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<T?> _execute;
        private readonly Func<T?, bool>? _canExecute;
        private readonly IErrorHandler? _errorHandler;

        public Command(
            Action<T?> execute,
            Func<T?, bool>? canExecute = null,
            IErrorHandler? errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public bool CanExecute(T? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(T? parameter)
        {
            if (CanExecute(parameter)) _execute.Invoke(parameter);
            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #region Explicit implementations
        bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);

        void ICommand.Execute(object? parameter) =>
            ((Action)(() => Execute((T?)parameter))).FireAndForgetSafe(_errorHandler);

        #endregion
    }
}
