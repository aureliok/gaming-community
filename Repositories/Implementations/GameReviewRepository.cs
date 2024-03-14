using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class GameReviewRepository : IGameReviewRepository
    {
        private readonly GamingCommunityDbContext _context;

        public GameReviewRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<GameReview> GetByIdAsync(int reviewId)
        {
            return await _context.GamesReviews.FirstOrDefaultAsync(x => x.ReviewId == reviewId);
        }

        public async Task<IEnumerable<GameReview>> GetAllAsync()
        {
            return await _context.GamesReviews.ToListAsync();
        }

        public async Task AddAsync(GameReview gameReview)
        {
            _context.GamesReviews.Add(gameReview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GameReview gameReview)
        {
            _context.GamesReviews.Update(gameReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int reviewId)
        {
            GameReview gameReview= await _context.GamesReviews.FindAsync(reviewId);
            if (gameReview != null)
            {
                _context.GamesReviews.Remove(gameReview);
                await _context.SaveChangesAsync();
            }
        }
    }
}
