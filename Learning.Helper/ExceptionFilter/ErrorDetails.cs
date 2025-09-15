using System.Text.Json;

namespace Learning.Helper.ExceptionFilter
{
    /// <summary>
    /// ErrorDetails.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// ErrorDetails - StatusCode.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// ErrorDetails - Name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// ErrorDetails - Message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// ErrorDetails - InnerExceptionMessage.
        /// </summary>
        public string? InnerExceptionMessage { get; set; }

        /// <summary>
        /// ErrorDetails - JsonSerializer.
        /// </summary>
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
