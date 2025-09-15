namespace Learning.Helper.ExceptionFilter
{
    /// <summary>
    /// BadRequestError.
    /// </summary>
    public class BadRequestError
    {
        /// <summary>
        /// BadRequestError - errors.
        /// </summary>
        public Dictionary<string, List<string>> errors { get; set; }  = new Dictionary<string, List<string>>();

        /// <summary>
        /// BadRequestError - title.
        /// </summary>
        public string title { get; } = "One or more validation errors occurred.";

        /// <summary>
        /// BadRequestError - status.
        /// </summary>
        public long status { get; } = 400L;

        /// <summary>
        /// BadRequestError - traceId.
        /// </summary>
        public string traceId { get; } = "0";
    }
}
