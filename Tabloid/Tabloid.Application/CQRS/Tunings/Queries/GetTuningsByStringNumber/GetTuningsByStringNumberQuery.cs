using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetTuningsByStringNumber
{
    public class GetTuningsByStringNumberQuery : IRequest<GuitarTuningDto[]>
    {
        public GetTuningsByStringNumberQuery(int stringNumber)
        {
            StringNumber = stringNumber;
        }

        public int StringNumber { get; set; }
    }
}
