using System.Net;

namespace Tabloid.Domain.Responses.HttpResponses
{
    public class BadRequestHttpResponse<T> : IHttpResponse<T>
    {
        public BadRequestHttpResponse(T obj, string error)
        {
            Object = obj;
            Error = error;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public T Object { get; set; }

        public string Error { get; }
    }
}
