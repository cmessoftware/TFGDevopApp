using System.Runtime.Serialization;

namespace TFGDevopsApp1.Common.Exceptions
{
    [Serializable]
    internal class MantisHTTPClientExeption : Exception
    {
        private Exception ex;

        public MantisHTTPClientExeption()
        {
        }

        public MantisHTTPClientExeption(Exception ex)
        {
            this.ex = ex;
        }

        public MantisHTTPClientExeption(string? message) : base(message)
        {
        }

        public MantisHTTPClientExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MantisHTTPClientExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}