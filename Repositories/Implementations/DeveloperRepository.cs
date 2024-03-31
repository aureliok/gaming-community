using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GamingCommunityDbContext _context;

        public DeveloperRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<Developer> GetByIdAsync(int developerId)
        {
            return await _context.Developers.FirstOrDefaultAsync(x => x.DeveloperId == developerId);
        }

        public async Task<int> GetIdByNameAsync(string developerName)
        {
            Developer developer = await _context.Developers.FirstOrDefaultAsync(x => x.DeveloperName == developerName);

            return developer.DeveloperId;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task AddAsync(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            _context.Developers.Update(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int developerId)
        {
            Developer developer = await _context.Developers.FindAsync(developerId);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();
            }
        }
    }
}