using System.Net;

namespace Tabloid.Domain.Responses
{
    public class InternalServerErrorResponse<T> : IResponse<T>
    {
        public InternalServerErrorResponse(T obj, string error)
        {
            Object = obj;
            Error = error;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public T Object { get; set; }

        public string Error { get; }
    }
}
