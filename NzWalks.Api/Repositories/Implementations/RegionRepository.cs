using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
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

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            try
            {
                var regions = await _nzWalksDbContext.Regions.ToListAsync();
                return regions;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
