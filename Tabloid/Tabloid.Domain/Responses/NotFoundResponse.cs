using System.Net;

namespace Tabloid.Domain.Responses
{
    public class NotFoundResponse<T> : IResponse<T>
    {
        public NotFoundResponse(T obj, string error)
        {
            Object = obj;
            Error = error;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public T Object { get; set; }

        public string Error { get; }
    }
}
