namespace TFGDevopsApp.Common.Exceptions
{
    [Serializable]
    internal class RestClientException : Exception
    {
        public RestClientException()
        {
        }

        public RestClientException(string? message) : base(message)
        {
        }

        public RestClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}