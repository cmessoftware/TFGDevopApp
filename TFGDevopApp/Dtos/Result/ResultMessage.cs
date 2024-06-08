namespace TFGDevopsApp.Core.Models.Result
{
    public class ResultMessage<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public T Data { get; set; }

    }
}
