namespace Tabloid.Domain.DataTransferObjects
{
    public class SongDto
    {
        public Guid Id { get; set; }

        public string SongName { get; set; }

        public int? SongNumberInAlbum { get; set; }

        public AlbumDto Album { get; set; }

        public ICollection<TabDto> Tabs { get; set; }

        public ICollection<GenreDto> Genres { get; set; }

        public ICollection<ArtistDto> Artists { get; set; }
    }
}
