using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllJustNames
{
    public class GetAllJustNamesQuery : IRequest<JustNameDto[]>
    {
    }
}
