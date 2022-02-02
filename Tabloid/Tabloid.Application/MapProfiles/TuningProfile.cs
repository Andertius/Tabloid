using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles
{
    public class TuningProfile : Profile
    {
        public TuningProfile()
        {
            CreateMap<GuitarTuning, GuitarTuningDto>();
            CreateMap<GuitarTuningDto, GuitarTuning>();
        }
    }
}
