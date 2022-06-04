using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles
{
    public class TabProfile : Profile
    {
        public TabProfile()
        {
            CreateMap<Tab, TabDto>();

            CreateMap<TabDto, Tab>()
                .ForMember(x => x.Tuning, opt => opt.Ignore())
                .ForMember(x => x.TuningId, opt => opt.MapFrom(x => x.Tuning.Id))
                .ForMember(x => x.Song, opt => opt.Ignore())
                .ForMember(x => x.SongId, opt => opt.MapFrom(x => x.Song.Id));
        }
    }
}
