using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetByIdAsync(int gameId);
        Task<IEnumerable<Game>> GetAllAsync();
        Task AddAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(int gameId);
    }
}
