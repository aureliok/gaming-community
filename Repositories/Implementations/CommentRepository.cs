using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly GamingCommunityDbContext _context;

        public CommentRepository(GamingCommunityDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetByIdAsync(int commentId)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int commentId)
        {
            Comment comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
