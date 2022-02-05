using System.Net;

namespace Tabloid.Domain.Responses
{
    public class OkResponse<T> : IResponse<T>
    {
        public OkResponse(T obj)
        {
            Object = obj;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.OK;

        public T Object { get; set; }

        public string Error => "";
    }
}
