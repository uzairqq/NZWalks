using NzWalks.Api.Dto;

namespace NzWalks.Api.Repositories.Intefaces
{
    public interface IWalkDifficultyRepository
    {
        Task<WalkDifficultyDto> AddAsync(AddUpdateWalkDifficultyDto addUpdateWalkDifficultyDto);
        Task<WalkDifficultyDto> UpdateAsync(Guid id, AddUpdateWalkDifficultyDto addUpdateWalkDifficultyDto);
        Task<IEnumerable<WalkDifficultyDto>> GetAllAsync();
        Task<WalkDifficultyDto> GetByIdAsync(Guid id);
        Task<WalkDifficultyDto> DeleteAsync(Guid id);
    }
}
