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

            CreateMap<AlbumDto, Album>();
        }
    }
}
