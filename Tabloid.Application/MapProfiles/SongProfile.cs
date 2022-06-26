using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles
{
    public  class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.SongName));

            CreateMap<SongDto, Song>()
                .ForMember(x => x.Album, opt => opt.Ignore())
                .ForMember(x => x.AlbumId, opt => opt.MapFrom(x => x.Album.Id))
                .ForMember(x => x.SongName, opt => opt.MapFrom(x => x.Name));
        }
    }
}
