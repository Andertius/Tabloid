namespace Tabloid.Domain.Entities
{
    public class AlbumSong : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public int SongNumberInAlbum { get; set; }


        public Guid SongId { get; set; }

        public Song Song { get; set; }

        public Guid AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
