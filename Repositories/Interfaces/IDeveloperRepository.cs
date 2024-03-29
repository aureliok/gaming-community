using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<Developer> GetByIdAsync(int developerId);
        Task<int> GetIdByNameAsync(string developerName);
        Task<IEnumerable<Developer>> GetAllAsync();
        Task AddAsync(Developer developer);
        Task UpdateAsync(Developer developer);
        Task DeleteAsync(int developerId);
    }
}
