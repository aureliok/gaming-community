using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class VoteRepository : IVoteRepository
    {
        private readonly GamingCommunityDbContext _context;

        public VoteRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<Vote> GetByIdAsync(int voteId)
        {
            return await _context.Votes.FirstOrDefaultAsync(x => x.VoteId == voteId);
        }

        public async Task<IEnumerable<Vote>> GetAllAsync()
        {
            return await _context.Votes.ToListAsync();
        }

        public async Task AddAsync(Vote vote)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vote vote)
        {
            _context.Votes.Update(vote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int voteId)
        {
            Vote vote = await _context.Votes.FindAsync(voteId);
            if (vote != null)
            {
                _context.Votes.Remove(vote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
