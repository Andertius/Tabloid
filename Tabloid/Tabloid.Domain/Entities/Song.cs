namespace Tabloid.Domain.Entities
{
    public class Song : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string SongName { get; set; }

        public int SongNumberInAlbum { get; set; }


        public Guid AlbumId { get; set; }

        public Album Album { get; set; }


        public ICollection<Tab> Tabs { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}
