using Tabloid.Domain.Enums;

namespace Tabloid.Domain.DataTransferObjects
{
    public class TuningDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public int StringNumber { get; set; }

        public string Name { get; set; }

        public Instrument Instrument { get; set; }

        public string Strings { get; set; }


        public ICollection<TabDto> Tabs { get; set; }
    }
}
