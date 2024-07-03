


namespace TFGDevopsApp.Common.Exceptions
{
    [Serializable]
    internal class TiempoInferiorAlRequeridoException : Exception
    {
        public TiempoInferiorAlRequeridoException()
        {
        }

        public TiempoInferiorAlRequeridoException(string? message) : base(message)
        {
        }

        public TiempoInferiorAlRequeridoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}