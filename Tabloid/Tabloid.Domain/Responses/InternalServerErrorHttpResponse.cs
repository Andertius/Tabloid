using System.Net;

namespace Tabloid.Domain.Responses.HttpResponses
{
    public class InternalServerErrorHttpResponse<T> : IHttpResponse<T>
    {
        public InternalServerErrorHttpResponse(T obj, string error)
        {
            Object = obj;
            Error = error;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public T Object { get; set; }

        public string Error { get; }
    }
}
