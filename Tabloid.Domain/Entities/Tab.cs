namespace Tabloid.Domain.Entities
{
    public class Tab : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Link { get; set; }

        public double? Difficulty { get; set; }


        public Guid TuningId { get; set; }

        public Tuning Tuning { get; set; }

        public Guid SongId { get; set; }

        public Song Song { get; set; }
    }
}
