using System.Runtime.Serialization;

namespace TFGDevopsApp.Common.Exceptions
{
    [Serializable]
    internal class EntityBadRequestException<T> : Exception where T : class
    {
        public EntityBadRequestException()
        {
        }

        public EntityBadRequestException(string? message) : base(message)
        {
        }

        public EntityBadRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityBadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}