using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IInboxMessageRepository
    {
        Task<InboxMessage> GetByIdAsync(int messageId);
        Task<IEnumerable<InboxMessage>> GetAllAsync();
        Task AddAsync(InboxMessage inboxMessage);
        Task UpdateAsync(InboxMessage inboxMessage);
        Task DeleteAsync(int messageId);
    }
}
