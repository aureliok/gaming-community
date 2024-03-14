using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IGameReviewRepository
    {
        Task<GameReview> GetByIdAsync(int reviewId);
        Task<IEnumerable<GameReview>> GetAllAsync();
        Task AddAsync(GameReview gameReview);
        Task UpdateAsync(GameReview gameReview);
        Task DeleteAsync(int reviewId);
    }
}
