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
            CreateMap<TabDto, Tab>();
        }
    }
}
