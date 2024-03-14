using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class GamingThreadRepository : IGamingThreadRepository
    {
        private readonly GamingCommunityDbContext _context;

        public GamingThreadRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<GamingThread> GetByIdAsync(int threadId)
        {
            return await _context.GamingThreads.FirstOrDefaultAsync(x => x.ThreadId == threadId);
        }

        public async Task<IEnumerable<GamingThread>> GetAllAsync()
        {
            return await _context.GamingThreads.ToListAsync();
        }

        public async Task AddAsync(GamingThread gamingThread)
        {
            _context.GamingThreads.Add(gamingThread);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GamingThread gamingThread)
        {
            _context.GamingThreads.Update(gamingThread);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int threadId)
        {
            GamingThread gamingThread= await _context.GamingThreads.FindAsync(threadId);
            if (gamingThread!= null)
            {
                _context.GamingThreads.Remove(gamingThread);
                await _context.SaveChangesAsync();
            }
        }
    }
}
