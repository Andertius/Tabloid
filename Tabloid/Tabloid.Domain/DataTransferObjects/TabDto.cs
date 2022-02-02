namespace Tabloid.Domain.DataTransferObjects
{
    public class TabDto
    {
        public Guid Id { get; set; }

        public string TabContent { get; set; }

        public double? Difficulty { get; set; }

        public string Instrument { get; set; }

        public GuitarTuningDto Tuning { get; set; }

        public SongDto Song { get; set; }
    }
}
