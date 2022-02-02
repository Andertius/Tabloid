using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Tunings.GetTuningByStringNumber
{
    public class GetTuningByStringNumberQuery : IRequest<GuitarTuningDto[]>
    {
        public GetTuningByStringNumberQuery(int stringNumber)
        {
            StringNumber = stringNumber;
        }

        public int StringNumber { get; set; }
    }
}
