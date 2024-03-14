using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IUserConnectionRepository
    {
        Task<UserConnection> GetByIdAsync(int connectionId);
        Task<IEnumerable<UserConnection>> GetAllAsync();
        Task AddAsync(UserConnection userConnection);
        Task UpdateAsync(UserConnection userConnection);
        Task DeleteAsync(int connectionId);
    }
}
