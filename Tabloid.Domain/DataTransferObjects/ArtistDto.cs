namespace Tabloid.Domain.DataTransferObjects
{
    public class ArtistDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<SongDto> Songs { get; set; }

        public ICollection<AlbumDto> Albums { get; set; }
    }
}
