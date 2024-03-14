using GamingCommunity.Entities;

namespace GamingCommunity.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetAllAsync();
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(int commentId);
    }
}
