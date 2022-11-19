using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetAllJustNames;

public class GetAllJustNamesQuery : IRequest<JustNameDto[]>
{
}
