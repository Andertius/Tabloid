using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.FindTuningById
{
    public class FindTuningByIdQuery : IRequest<TuningDto>
    {
        public FindTuningByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
