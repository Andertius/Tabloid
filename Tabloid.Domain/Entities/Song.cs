using System;
using System.Collections.Generic;

namespace Tabloid.Domain.Entities;

public class Song : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string SongName { get; set; } = null!;

    public int? SongNumberInAlbum { get; set; }

    public bool FullyMastered { get; set; }

    public bool IsFavourite { get; set; }


    public Guid AlbumId { get; set; }

    public Album? Album { get; set; }


    public ICollection<Tab>? Tabs { get; set; }

    public ICollection<Genre>? Genres { get; set; }

    public ICollection<Artist>? Artists { get; set; }
}
