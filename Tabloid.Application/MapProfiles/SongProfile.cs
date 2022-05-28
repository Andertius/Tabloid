using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles
{
    public  class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();
        }
    }
}
