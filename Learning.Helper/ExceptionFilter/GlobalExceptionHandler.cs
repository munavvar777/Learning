//using Microsoft.AspNetCore.Http;
//using Npgsql;
//using System.Net;
//using Learning.Helper.ExceptionFilter.CustomExceptions;

//namespace Learning.Helper.ExceptionFilter
//{
//    /// <summary>
//    /// GlobalExceptionHandler.
//    /// </summary>
//    public class GlobalExceptionHandler : IExceptionHandler
//    {
//        /// <summary>
//        /// GlobalExceptionHandler - TryHandleAsync.
//        /// </summary>
//        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
//        {
//            //_logger.LogError($"An error occurred while processing your request: {exception.Message}");

//            //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
//            httpContext.Response.ContentType = "application/json";

//            var errorDetail = new ErrorDetails
//            {
//                Message = exception.Message,
//                InnerExceptionMessage = exception.InnerException?.Message ?? string.Empty
//            };

//            switch (exception)
//            {
//                //case BadHttpRequestException:
//                //    errorDetail.StatusCode = (int)HttpStatusCode.BadRequest;
//                //    errorDetail.Name = exception.GetType().Name;
//                //    break;
//                case NotImplementedException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.NotImplemented;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case UnauthorizedAccessException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.Unauthorized;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case BusinessRuleException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case NotFoundException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.NotFound;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case NoContentException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.NoContent;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case InvalidOperationException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case HttpStatusCodeException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.UnprocessableContent;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                case NpgsqlException:
//                    errorDetail.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
//                    errorDetail.Name = exception.GetType().Name;
//                    break;
//                default:
//                    errorDetail.StatusCode = (int)HttpStatusCode.InternalServerError;
//                    errorDetail.Name = "Internal Server Error";
//                    break;
//            }

//            httpContext.Response.StatusCode = errorDetail.StatusCode;

//            //await httpContext
//            //       .Response
//            //       .WriteAsJsonAsync(errorDetail, cancellationToken);

//            return true;
//        }

//    }
//}
