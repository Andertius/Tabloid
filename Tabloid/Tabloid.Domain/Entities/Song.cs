namespace Tabloid.Domain.Entities
{
    public class Song : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string SongName { get; set; }


        public ICollection<Tab> Tabs { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public Guid AlbumSongId { get; set; }

        public AlbumSong AlbumSong { get; set; }
    }
}
