using System.Net;

namespace Learning.Helper.ExceptionFilter.CustomExceptions
{
    /// <summary>
    /// NoContentException.
    /// </summary>
    public class NoContentException : Exception
    {
        /// <summary>
        /// NoContentException Property - StatusCode.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// NoContentException Property - EntityType.
        /// </summary>
        public string entityType { get; set; } = string.Empty;

        /// <summary>
        /// NoContentException - Constructor.
        /// </summary>
        public NoContentException()
        {
        }

        /// <summary>
        /// NoContentException - Message.
        /// </summary>
        public NoContentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// NoContentException - Message and Inner Exception.
        /// </summary>
        public NoContentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// NoContentException - Excpetion.
        /// </summary>
        public NoContentException(Exception ex, int statuscode = (int)HttpStatusCode.NoContent)
            : base(ex.Message)
        {
            StatusCode = statuscode;
        }

        /// <summary>
        /// NoContentException - EntityType and Message.
        /// </summary>
        public NoContentException(string message, string? currentEntityType = null)
             : base(message)
        {
            entityType = string.IsNullOrEmpty(currentEntityType) ? string.Empty : currentEntityType;
        }
    }
}
