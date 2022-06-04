using Tabloid.Domain.Enums;

namespace Tabloid.Domain.Entities
{
    public class Album : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public int Year { get; set; }

        public AlbumType AlbumType { get; set; }


        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }


        public ICollection<Song> Songs { get; set; }
    }
}
