using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();

            CreateMap<GenreDto, Genre>();
        }
    }
}
