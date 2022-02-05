namespace Tabloid.Domain.DataTransferObjects
{
    public class GenreDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
