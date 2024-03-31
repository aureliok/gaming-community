using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        Task<Publisher> GetByIdAsync(int publisherId);
        Task<int> GetIdByNameAsync(string publisherName);
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task AddAsync(Publisher publisher);
        Task UpdateAsync(Publisher publisher);
        Task DeleteAsync(int publisherId);
    }
}
