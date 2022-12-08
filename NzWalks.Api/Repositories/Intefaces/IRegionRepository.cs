using NzWalks.Api.Dto;
using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Repositories.Intefaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<RegionsDto>> GetAllAsync();
        Task<RegionsDto> GetRegionAsync(Guid id);

        Task<RegionsDto> PostRegionAsync(AddRegionDto dto);
    }
}
