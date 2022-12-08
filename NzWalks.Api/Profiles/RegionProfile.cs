using AutoMapper;
using NzWalks.Api.Dto;
using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<RegionsDto, Region>().ReverseMap();
        }
    }
}
