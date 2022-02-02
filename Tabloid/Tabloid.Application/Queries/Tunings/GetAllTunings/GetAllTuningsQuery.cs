using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Tunings.GetAllTunings
{
    public class GetAllTuningsQuery : IRequest<GuitarTuningDto[]>
    {
    }
}
