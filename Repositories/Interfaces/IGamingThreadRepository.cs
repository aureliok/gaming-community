using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IGamingThreadRepository
    {
        Task<GamingThread> GetByIdAsync(int threadId);
        Task<IEnumerable<GamingThread>> GetAllAsync();
        Task AddAsync(GamingThread gamingThread);
        Task UpdateAsync(GamingThread gamingThread);
        Task DeleteAsync(int threadId);
    }
}
