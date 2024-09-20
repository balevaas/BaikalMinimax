using ViewModelBase.Commands.ErrorHandlers;

namespace ViewModelBase.Commands
{
    public static class Utilities
    {
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler? handler)
        {
            try
            {
                await task;
            }
            catch (OperationCanceledException ex)
            {
                if (handler is IErrorCancelHandler handlerWithCancel)
                    handlerWithCancel.HandleCancel(ex);
                else handler?.HandleError(ex);
            }
            catch (ResultNotFoundException ex)
            {
                if (handler is IErrorNotFoundHandler handlerWithNotFound)
                    handlerWithNotFound.HandleResultNotFound(ex);
                else handler?.HandleError(ex);
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }

        public static void FireAndForgetSafe(this Action action, IErrorHandler? handler)
        {
            try
            {
                action.Invoke();
            }
            catch (ResultNotFoundException ex)
            {
                if (handler is IErrorNotFoundHandler handlerWithNotFound)
                    handlerWithNotFound.HandleResultNotFound(ex);
                else handler?.HandleError(ex);
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}
