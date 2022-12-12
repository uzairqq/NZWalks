using NzWalks.Api.Dto;

namespace NzWalks.Api.Repositories.Intefaces
{
    public interface IWalkRepository
    {
        Task<WalksDto> PostWalksAsync(AddUpdateWalksDto addUpdateWalksDto);

        Task<WalksDto> UpdateWalksAsync(Guid id,AddUpdateWalksDto addUpdateWalksDto);

        Task<WalksDto> DeleteWalksAsync(Guid id);

        Task<IEnumerable<WalksDto>> GetAllWalksAsync();

        Task<WalksDto> GetWalkAsync(Guid id);
    }
}
