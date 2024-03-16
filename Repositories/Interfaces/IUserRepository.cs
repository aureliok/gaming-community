using GamingCommunity.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByUsernameOrEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);
    }
}
