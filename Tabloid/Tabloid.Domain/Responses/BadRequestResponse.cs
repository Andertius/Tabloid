using System.Net;

namespace Tabloid.Domain.Responses
{
    public class BadRequestResponse<T> : IResponse<T>
    {
        public BadRequestResponse(T obj, string error)
        {
            Object = obj;
            Error = error;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public T Object { get; set; }

        public string Error { get; }
    }
}
