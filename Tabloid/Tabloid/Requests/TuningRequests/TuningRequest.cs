using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Requests.TuningRequests
{
    public class TuningRequest
    {
        public TuningRequest(GuitarTuningDto tuning)
        {
            Tuning = tuning;
        }

        public GuitarTuningDto Tuning { get; set; }
    }
}
