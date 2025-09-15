using Newtonsoft.Json.Linq;
using System.Net;

namespace Learning.Helper.ExceptionFilter.CustomExceptions
{
    /// <summary>
    /// HttpStatusCodeException.
    /// </summary>
    public class HttpStatusCodeException : Exception
    {
        /// <summary>
        /// HttpStatusCodeException Propert - StatusCode.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// HttpStatusCodeException Propert - ContentType.
        /// </summary>
        public string ContentType { get; set; } = @"text/plain";

        /// <summary>
        /// HttpStatusCodeException - Status Code.
        /// </summary>
        public HttpStatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// HttpStatusCodeException - Status Code and Message.
        /// </summary>
        public HttpStatusCodeException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// HttpStatusCodeException - Status Code and Inner Exception.
        /// </summary>
        public HttpStatusCodeException(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString()) { }

        /// <summary>
        /// HttpStatusCodeException - Status Code and Error JSON Object.
        /// </summary>
        public HttpStatusCodeException(HttpStatusCode statusCode, JObject errorObject)
            : this(statusCode, errorObject.ToString())
        {
            ContentType = @"application/json";
        }
    }
}
