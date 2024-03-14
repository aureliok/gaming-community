using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IVoteRepository
    {
        Task<Vote> GetByIdAsync(int voteId);
        Task<IEnumerable<Vote>> GetAllAsync();
        Task AddAsync(Vote vote);
        Task UpdateAsync(Vote vote);
        Task DeleteAsync(int voteId);
    }
}
