using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetAllTunings;

public class GetAllTuningsQuery : IRequest<TuningDto[]>
{
}
