using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.GetAllJustNames
{
    public class GetAllJustNamesQuery : IRequest<JustNameDto[]>
    {
    }
}
