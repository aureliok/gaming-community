using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class InboxMessageRepository : IInboxMessageRepository
    {
        private readonly GamingCommunityDbContext _context;

        public InboxMessageRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<InboxMessage> GetByIdAsync(int messageId)
        {
            return await _context.InboxMessages.FirstOrDefaultAsync(x => x.MessageId == messageId);
        }

        public async Task<IEnumerable<InboxMessage>> GetAllAsync()
        {
            return await _context.InboxMessages.ToListAsync();
        }

        public async Task AddAsync(InboxMessage inboxMessage)
        {
            _context.InboxMessages.Add(inboxMessage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InboxMessage inboxMessage)
        {
            _context.InboxMessages.Update(inboxMessage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int messageId)
        {
            InboxMessage inboxMessage = await _context.InboxMessages.FindAsync(messageId);
            if (inboxMessage != null)
            {
                _context.InboxMessages.Remove(inboxMessage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
