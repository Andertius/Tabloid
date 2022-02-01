namespace Tabloid.Domain.Entities
{
    public class GuitarTuning : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public int StringNumber { get; set; }

        public string Name { get; set; }

        public string Tuning { get; set; }


        public ICollection<Tab> Tabs { get; set; }
    }
}
