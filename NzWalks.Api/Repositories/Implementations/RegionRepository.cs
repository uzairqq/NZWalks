using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Dto;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Repositories.Intefaces;

namespace NzWalks.Api.Repositories.Implementations
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext _nzWalksDbContext;
        private readonly IMapper _mapper;

        public RegionRepository(NzWalksDbContext nzWalksDbContext, IMapper mapper)
        {
            _nzWalksDbContext = nzWalksDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionsDto>> GetAllAsync()
        {
            try
            {
                var regions = await _nzWalksDbContext.Regions.ToListAsync();
                var regionsDto = _mapper.Map<IEnumerable<RegionsDto>>(regions);
                return regionsDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RegionsDto> GetRegionAsync(Guid id)
        {
            try
            {
                var region = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(i => i.Id == id);
                var regionDto=_mapper.Map<RegionsDto>(region);
                return regionDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
