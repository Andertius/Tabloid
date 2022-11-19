using System;
using System.Collections.Generic;

namespace Tabloid.Domain.DataTransferObjects
{
    public class GenreDto : IDto<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<JustNameDto> Songs { get; set; }
    }
}
