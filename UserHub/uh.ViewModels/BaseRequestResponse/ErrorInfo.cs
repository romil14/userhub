namespace uh.ViewModels.BaseRequestResponse
{
    public class ErrorInfo
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }

        public ErrorInfo(){ }

        public ErrorInfo(string errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }
    }
}
