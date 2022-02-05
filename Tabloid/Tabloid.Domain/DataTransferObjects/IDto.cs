namespace Tabloid.Domain.DataTransferObjects
{
    public interface IDto<T>
    {
        T Id { get; set; }
    }
}
