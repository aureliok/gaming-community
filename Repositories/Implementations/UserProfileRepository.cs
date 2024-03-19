using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly GamingCommunityDbContext _context;

        public UserProfileRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> GetByIdAsync(int userId)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task AddAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            UserProfile userProfile = await _context.UserProfiles.FindAsync(userId);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
                await _context.SaveChangesAsync();
            }
        }
    }
}
