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
        public RegionRepository(NzWalksDbContext nzWalksDbContext)
        {
            _nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<IEnumerable<RegionsDto>> GetAllAsync()
        {
            try
            {
                var regions = await _nzWalksDbContext.Regions.Select(i => new RegionsDto()
                {
                    Id=i.Id,
                    Area=i.Area,
                    Code=i.Code,
                    Lat=i.Lat,
                    Long=i.Long,
                    Name=i.Name,
                    Population=i.Population

                }).ToListAsync();
                return regions;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
