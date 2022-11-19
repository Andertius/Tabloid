using AutoMapper;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.MapProfiles;

public class TuningProfile : Profile
{
    public TuningProfile()
    {
        CreateMap<Tuning, TuningDto>();

        CreateMap<TuningDto, Tuning>();

        CreateMap<Tuning, JustNameDto>();

        CreateMap<TuningDto, JustNameDto>();
    }
}
