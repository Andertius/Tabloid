using System.Net;

namespace Tabloid.Domain.Responses.HttpResponses
{
    public class OkHttpResponse<T> : IHttpResponse<T>
    {
        public OkHttpResponse(T obj)
        {
            Object = obj;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.OK;

        public T Object { get; set; }

        public string Error => "";
    }
}
