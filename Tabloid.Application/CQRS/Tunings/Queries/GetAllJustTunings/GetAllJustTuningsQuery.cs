using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetAllJustTunings
{
    public class GetAllJustTuningsQuery : IRequest<TuningDto[]>
    {
    }
}
