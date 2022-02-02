namespace Tabloid.Domain.DataTransferObjects
{
    public class AlbumDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public int Year { get; set; }

        public ArtistDto Artist { get; set; }

        public ICollection<SongDto> Songs { get; set; }
    }
}
