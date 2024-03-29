﻿namespace Tabloid.Domain.Entities
{
    public class Genre : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public ICollection<Song> Songs { get; set; }
    }
}
