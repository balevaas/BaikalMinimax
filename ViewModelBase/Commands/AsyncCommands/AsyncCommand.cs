using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelBase.Commands.ErrorHandlers;

namespace ViewModelBase.Commands.AsyncCommands
{
    public class AsyncCommand : AsyncCommandBase, IAsyncCommand
    {
        private readonly Func<CancellationToken, Task> _execute;
        private readonly Func<bool>? _canExecute;

        public AsyncCommand(
            Func<CancellationToken, Task> execute,
            Func<bool>? canExecute = null,
            IErrorHandler? errorCancelHandler = null,
            CancellationToken cancel = default)
                : base(errorCancelHandler, true, cancel)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public AsyncCommand(
            Func<Task> execute,
            Func<bool>? canExecute = null,
            IErrorHandler? errorHandler = null)
            : base(errorHandler, false, CancellationToken.None)
        {
            _execute = _ => execute.Invoke();
            _canExecute = canExecute;
        }

        public bool CanExecute() =>
            !IsExecuting &&
            (_canExecute?.Invoke() ?? true) &&
            !InnerCancellationToken.IsCancellationRequested;

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    IsExecuting = true;
                    await _execute.Invoke(InnerCancellationToken);
                }
                finally
                {
                    IsExecuting = false;
                }
            }
            RaiseCanExecuteChanged();
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object? parameter) => CanExecute();

        void ICommand.Execute(object? parameter) =>
            ExecuteAsync().FireAndForgetSafeAsync(ErrorCancelHandler);
        #endregion
    }
}
