using System.Net;

namespace Tabloid.Domain.Responses
{
    public interface IResponse<T>
    {
        HttpStatusCode StatusCode { get; }

        T Object { get; set; }

        string Error { get; }
    }
}
