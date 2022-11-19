using System;
using System.Collections.Generic;

namespace Tabloid.Domain.DataTransferObjects
{
    public class SongDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? SongNumberInAlbum { get; set; }

        public bool FullyMastered { get; set; }

        public bool IsFavourite { get; set; }


        public AlbumDto Album { get; set; }


        public ICollection<TabDto> Tabs { get; set; }

        public ICollection<GenreDto> Genres { get; set; }

        public ICollection<ArtistDto> Artists { get; set; }
    }
}
