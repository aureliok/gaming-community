using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly GamingCommunityDbContext _context;

        public UserConnectionRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<UserConnection> GetByIdAsync(int connectionId)
        {
            return await _context.UserConnections.FirstOrDefaultAsync(x => x.ConnectionId == connectionId);
        }

        public async Task<IEnumerable<UserConnection>> GetAllAsync()
        {
            return await _context.UserConnections.ToListAsync();
        }

        public async Task AddAsync(UserConnection userConnection)
        {
            _context.UserConnections.Add(userConnection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserConnection userConnection)
        {
            _context.UserConnections.Update(userConnection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int connectionId)
        {
            UserConnection userConnection = await _context.UserConnections.FindAsync(connectionId);
            if (userConnection != null)
            {
                _context.UserConnections.Remove(userConnection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
