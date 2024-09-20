namespace ViewModelBase.Commands.ErrorHandlers
{
    public interface IErrorCancelHandler : IErrorHandler
    {
        void HandleCancel(OperationCanceledException ex);
    }
    public interface IErrorNotFoundHandler : IErrorHandler
    {
        void HandleResultNotFound(ResultNotFoundException ex);
    }
    public class ResultNotFoundException : Exception
    {
        public ResultNotFoundException(string? message) : base(message) { }
    }
}
