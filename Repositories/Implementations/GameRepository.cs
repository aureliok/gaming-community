using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class GameRepository : IGameRepository
    {
        private readonly GamingCommunityDbContext _context;

        public GameRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<Game> GetByIdAsync(int gameId)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.GameId == gameId);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task AddAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int gameId)
        {
            Game game = await _context.Games.FindAsync(gameId);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}
