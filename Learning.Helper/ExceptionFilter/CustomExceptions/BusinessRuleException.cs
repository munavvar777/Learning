using System.Net;

namespace Learning.Helper.ExceptionFilter.CustomExceptions
{
    /// <summary>
    /// BusinessRuleException.
    /// </summary>
    [Serializable]
    public class BusinessRuleException : Exception
    {
        /// <summary>
        /// BusinessRuleException Property - StatusCode.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// BusinessRuleException Property - RecordStatus.
        /// </summary>
        public RecordStatus RecordStatus { get; set; } = RecordStatus.Failed;

        /// <summary>
        /// BusinessRuleException Property - EntityType.
        /// </summary>
        public string entityType { get; set; } = string.Empty;

        /// <summary>
        /// BusinessRuleException - Message.
        /// </summary>
        public BusinessRuleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// BusinessRuleException - RecordStatus, EntityType and Message.
        /// </summary>
        public BusinessRuleException(string message, RecordStatus recordStatus, string? currentEntityType = null)
           : base(message)
        {
            RecordStatus = recordStatus;
            entityType = string.IsNullOrEmpty(currentEntityType) ? string.Empty : currentEntityType ;
        }


        /// <summary>
        /// BusinessRuleException - Message and Inner Exception.
        /// </summary>
        public BusinessRuleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// BusinessRuleException - Exception.
        /// </summary>
        public BusinessRuleException(Exception ex, int statuscode = (int)HttpStatusCode.InternalServerError)
            : base(ex.Message)
        {
            StatusCode = statuscode;
        }
    }
}
