using System.Net;

namespace Tabloid.Domain.Responses.HttpResponses
{
    public interface IHttpResponse<T>
    {
        HttpStatusCode StatusCode { get; }

        T Object { get; set; }

        string Error { get; }
    }
}
