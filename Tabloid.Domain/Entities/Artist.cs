namespace Tabloid.Domain.Entities
{
    public class Artist : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }


        public ICollection<Song> Songs { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
