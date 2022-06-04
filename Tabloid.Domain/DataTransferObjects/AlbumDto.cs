using Tabloid.Domain.Enums;

namespace Tabloid.Domain.DataTransferObjects
{
    public class AlbumDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public int Year { get; set; }

        public AlbumType AlbumType { get; set; }


        public ArtistDto Artist { get; set; }

        public ICollection<SongDto> Songs { get; set; }
    }
}
