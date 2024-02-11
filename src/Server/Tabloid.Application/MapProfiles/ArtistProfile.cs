using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles;

public class ArtistProfile : Profile
{
    public ArtistProfile()
    {
        CreateMap<Artist, ArtistDto>();

        CreateMap<ArtistDto, Artist>();

        CreateMap<Artist, JustNameDto>();

        CreateMap<ArtistDto, JustNameDto>();
    }
}
