using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Repositories.Intefaces
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
    }
}
