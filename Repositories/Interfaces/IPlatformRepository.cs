using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IPlatformRepository
    {
        Task<Platform> GetByIdAsync(int platformId);
        Task<int> GetIdByNameAsync(string platformName);
        Task<IEnumerable<Platform>> GetAllAsync();
        Task AddAsync(Platform platform);
        Task UpdateAsync(Platform platform);
        Task DeleteAsync(int platformId);
    }
}
