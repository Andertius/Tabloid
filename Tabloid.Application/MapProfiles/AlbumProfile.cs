using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumDto>();

            CreateMap<AlbumDto, Album>()
                .ForMember(x => x.Artist, opt => opt.Ignore())
                .ForMember(x => x.ArtistId, opt => opt.MapFrom(x => x.Artist.Id));

            CreateMap<Album, JustNameDto>();

            CreateMap<AlbumDto, JustNameDto>();
        }
    }
}
