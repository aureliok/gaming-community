using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly GamingCommunityDbContext _context;

        public PlatformRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<Platform> GetByIdAsync(int platformId)
        {
            return await _context.Platforms.FirstOrDefaultAsync(x => x.PlatformId == platformId);
        }

        public async Task<int> GetIdByNameAsync(string platformName)
        {
            Platform platform = await _context.Platforms.FirstOrDefaultAsync(x => x.PlatformName == platformName);

            return platform != null ? platform.PlatformId : -1;
        }

        public async Task<IEnumerable<Platform>> GetAllAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task AddAsync(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Platform platform)
        {
            _context.Platforms.Update(platform);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int platformId)
        {
            Platform platform = await _context.Platforms.FindAsync(platformId);
            if (platform != null)
            {
                _context.Platforms.Remove(platform);
                await _context.SaveChangesAsync();
            }
        }
    }
}
