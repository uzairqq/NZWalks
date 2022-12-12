using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Dto;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Repositories.Intefaces;
using System.Security;

namespace NzWalks.Api.Repositories.Implementations
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NzWalksDbContext _nzWalksDbContext;

        public WalkRepository(NzWalksDbContext nzWalksDbContext)
        {
            _nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<WalksDto> DeleteWalksAsync(Guid id)
        {
            try
            {
                var walk = await _nzWalksDbContext.Walks.FirstOrDefaultAsync(i => i.Id == id);
                if (walk == null)
                {
                    return null;
                }
                _nzWalksDbContext.Walks.Remove(walk);
                await _nzWalksDbContext.SaveChangesAsync();

                var walkDtoMapping = new WalksDto()
                {
                    Id = walk.Id,
                    Name = walk.Name,
                    Length = walk.Length,
                    RegionId = walk.RegionId,
                    WalkDifficultyId = walk.WalkDifficultyId
                };

                return walkDtoMapping;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<WalksDto>> GetAllWalksAsync()
        {
            try
            {
                var walks = await _nzWalksDbContext.Walks
                    .Include(i => i.Region)
                    .Include(u => u.WalkDifficulty)
                    .Select(i => new WalksDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Length = i.Length,
                        RegionId = i.RegionId,
                        WalkDifficultyId = i.WalkDifficultyId,
                        Region=i.Region.Name,
                        WalkDifficulty=i.WalkDifficulty.Code
                    }).ToListAsync();

                return walks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WalksDto> GetWalkAsync(Guid id)
        {
            try
            {
                var walk = await _nzWalksDbContext.Walks
                    .Include(i => i.Region)
                    .Include(u => u.WalkDifficulty)
                    .FirstOrDefaultAsync(i => i.Id == id);
                if (walk == null)
                {
                    return null;
                }
                var mappedWalkDto = new WalksDto()
                {
                    Id = walk.Id,
                    Name = walk.Name,
                    Length = walk.Length,
                    RegionId = walk.RegionId,
                    WalkDifficultyId = walk.WalkDifficultyId,
                    Region = walk.Region.Name,
                    WalkDifficulty=walk.WalkDifficulty.Code

                };
                return mappedWalkDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WalksDto> PostWalksAsync(AddUpdateWalksDto addUpdateWalksDto)
        {
            try
            {
                var walk = await _nzWalksDbContext.Walks.AddAsync(new Walk()
                {
                    Name = addUpdateWalksDto.Name,
                    Length = addUpdateWalksDto.Length,
                    RegionId = addUpdateWalksDto.RegionId,
                    WalkDifficultyId = addUpdateWalksDto.WalkDifficultyId,
                });
                if (walk == null)
                {
                    return null;
                }
                await _nzWalksDbContext.SaveChangesAsync();

                var mappedWalkDto = new WalksDto()
                {

                    Id = walk.Entity.Id,
                    Name = walk.Entity.Name,
                    Length = walk.Entity.Length,
                    RegionId = walk.Entity.RegionId,
                    WalkDifficultyId = walk.Entity.WalkDifficultyId,
                };
                return mappedWalkDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WalksDto> UpdateWalksAsync(Guid id, AddUpdateWalksDto addUpdateWalksDto)
        {
            try
            {
                var existingWalks = await _nzWalksDbContext.Walks.FirstOrDefaultAsync(i => i.Id == id);
                if (existingWalks == null)
                {
                    return null;
                }
                existingWalks.Name = addUpdateWalksDto.Name;
                existingWalks.Length = addUpdateWalksDto.Length;
                existingWalks.RegionId = addUpdateWalksDto.RegionId;
                existingWalks.WalkDifficultyId = addUpdateWalksDto.WalkDifficultyId;
                _nzWalksDbContext.Walks.Update(existingWalks);
                await _nzWalksDbContext.SaveChangesAsync();

                var mappedWalkDto = new WalksDto()
                {
                    Id = existingWalks.Id,
                    Name = existingWalks.Name,
                    Length = existingWalks.Length,
                    RegionId = existingWalks.RegionId,
                    WalkDifficultyId = existingWalks.WalkDifficultyId,
                };

                return mappedWalkDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
