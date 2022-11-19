using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.GetAllJustNames;

public class GetAllJustNamesQuery : IRequest<JustNameDto[]>
{
}
