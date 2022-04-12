using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetTuningByName
{
    public class GetTuningByNameQuery : IRequest<GuitarTuningDto>
    {
        public GetTuningByNameQuery(string name)
        {
            TuningName = name;
        }

        public string TuningName { get; set; }
    }
}
