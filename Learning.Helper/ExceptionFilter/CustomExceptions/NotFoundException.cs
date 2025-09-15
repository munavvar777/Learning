using System.Net;

namespace Learning.Helper.ExceptionFilter.CustomExceptions
{
    /// <summary>
    /// NotFoundException.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// NotFoundException Property - StatusCode.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// NotFoundException Property - EntityType.
        /// </summary>
        public string entityType { get; set; } = string.Empty;

        /// <summary>
        /// NotFoundException - Message.
        /// </summary>
        public NotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// NotFoundException - EntityType and Message.
        /// </summary>
        public NotFoundException(string message, string? currentEntityType = null)
             : base(message)
        {
            entityType = string.IsNullOrEmpty(currentEntityType) ? string.Empty : currentEntityType;
        }

        /// <summary>
        /// NotFoundException - Message and Inner Exception
        /// </summary>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// NotFoundException - Exception.
        /// </summary>
        public NotFoundException(Exception ex, int statuscode = (int)HttpStatusCode.InternalServerError)
            : base(ex.Message)
        {
            StatusCode = statuscode;
        }
    }
}
