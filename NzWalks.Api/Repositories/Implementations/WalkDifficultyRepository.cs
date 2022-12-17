using NzWalks.Api.Data;
using NzWalks.Api.Dto;
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

        public Task<WalkDifficultyDto> AddAsync(AddUpdateWalkDifficulty addUpdateWalkDifficultyDto)
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficultyDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WalkDifficultyDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficultyDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WalkDifficultyDto> UpdateAsync(Guid id, AddUpdateWalkDifficulty addUpdateWalkDifficultyDto)
        {
            throw new NotImplementedException();
        }
    }
}
