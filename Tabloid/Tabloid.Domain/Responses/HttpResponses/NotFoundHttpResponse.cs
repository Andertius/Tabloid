using System.Net;

namespace Tabloid.Domain.Responses.HttpResponses
{
    public class NotFoundHttpResponse<T> : IHttpResponse<T>
    {
        public NotFoundHttpResponse(T obj, string error)
        {
            Object = obj;
            Error = error;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public T Object { get; set; }

        public string Error { get; }
    }
}
