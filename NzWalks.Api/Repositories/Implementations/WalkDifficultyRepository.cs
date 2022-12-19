using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Dto;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Repositories.Intefaces;

namespace NzWalks.Api.Repositories.Implementations
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NzWalksDbContext _nzWalksDbContext;
        public WalkDifficultyRepository(NzWalksDbContext nzWalksDbContext)
        {
            _nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<WalkDifficultyDto> AddAsync(AddUpdateWalkDifficultyDto addUpdateWalkDifficultyDto)
        {
            try
            {
                var walkDifficulty = await _nzWalksDbContext.WalkDifficulties.AddAsync(new WalkDifficulty()
                {
                    Code = addUpdateWalkDifficultyDto.Code
                });

                if (walkDifficulty.Entity.Id == Guid.Empty)
                {
                    return null;
                }
                await _nzWalksDbContext.SaveChangesAsync();


                var mappedDto = new WalkDifficultyDto()
                {
                    Id = walkDifficulty.Entity.Id,
                    Code = walkDifficulty.Entity.Code
                };
                return mappedDto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WalkDifficultyDto> DeleteAsync(Guid id)
        {
            try
            {
                var walkDifficulty = await _nzWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(i => i.Id == id);
                _nzWalksDbContext.WalkDifficulties.Remove(walkDifficulty);
                await _nzWalksDbContext.SaveChangesAsync();

                var mappedDto = new WalkDifficultyDto()
                {
                    Id = walkDifficulty.Id,
                    Code = walkDifficulty.Code
                };
                return mappedDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<WalkDifficultyDto>> GetAllAsync()
        {
            try
            {
                var walkDifficulties = await _nzWalksDbContext.WalkDifficulties
                    .AsNoTracking()
                    .Select(i => new WalkDifficultyDto()
                    {
                        Id = i.Id,
                        Code = i.Code
                    })
                    .ToListAsync();
                return walkDifficulties;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WalkDifficultyDto> GetByIdAsync(Guid id)
        {
            try
            {
                var walkDifficulties = await _nzWalksDbContext.WalkDifficulties
                    .Where(i => i.Id == id)
                    .Select(i => new WalkDifficultyDto()
                    {
                        Id = i.Id,
                        Code = i.Code
                    })
                    .FirstOrDefaultAsync();
                return walkDifficulties;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WalkDifficultyDto> UpdateAsync(Guid id, AddUpdateWalkDifficultyDto addUpdateWalkDifficultyDto)
        {
            var savedWalkDifficultyFromDb = await _nzWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(i => i.Id == id);
            if (savedWalkDifficultyFromDb == null)
            {
                savedWalkDifficultyFromDb.Code = addUpdateWalkDifficultyDto.Code;
            }
            _nzWalksDbContext.WalkDifficulties.Update(savedWalkDifficultyFromDb);
            await _nzWalksDbContext.SaveChangesAsync();
            var mappedDto = new WalkDifficultyDto()
            {
                Id = savedWalkDifficultyFromDb.Id,
                Code = savedWalkDifficultyFromDb.Code
            };
            return mappedDto;
        }
    }
}
