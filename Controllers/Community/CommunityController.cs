using GamingCommunity.Entities;
using GamingCommunity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace GamingCommunity.Controllers.Community
{
    public class CommunityController : Controller
    {
        private readonly GamingCommunityDbContext _context;

        public CommunityController(GamingCommunityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Gaming")]
        public IActionResult Gaming()
        {
            List<GamingThreadViewModel> gamingThreads = _context.GamingThreads
                .GroupJoin(_context.Users,
                           gamingThread => gamingThread.UserId,
                           user => user.UserId,
                           (gamingThread, users) => new { gamingThread, users })
                .SelectMany(
                    group => group.users.DefaultIfEmpty(),
                    (group, user) => new
                    {
                        GThread = group.gamingThread,
                        GUser = user
                    })
                .GroupJoin(_context.Comments,
                           combined => combined.GThread.ThreadId,
                           comment => comment.ThreadId,
                           (combined, comments) => new
                           {
                               combined.GThread,
                               combined.GUser,
                               Comments = comments
                           })
                .SelectMany(
                    group => group.Comments.DefaultIfEmpty(),
                    (group, comment) => new
                    {
                        group.GThread,
                        group.GUser,
                        Comment = comment
                    })
                .GroupBy(
                    combined => new
                    {
                        combined.GThread.ThreadId,
                        combined.GThread.Title,
                        combined.GThread.Content,
                        combined.GThread.CreatedAt,
                        combined.GUser.Username
                    })
                .Select(group => new GamingThreadViewModel
                {
                    ThreadId = group.Key.ThreadId,
                    Title = group.Key.Title,
                    Content = group.Key.Content,
                    CreatedAt = group.Key.CreatedAt,
                    Username = group.Key.Username,
                    CommentsCount = group.Count()
                })
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return View(gamingThreads);
        }

        public IActionResult YourProfile()
        {
            return View();
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            List<GameReviewViewModel> gamingReviews = _context.GamesReviews
                .GroupJoin(_context.Games,
                          review => review.GameId,
                          game => game.GameId,
                          (review, game) => new { review, game })
                .SelectMany(group => group.game.DefaultIfEmpty(),
                (group, game) => new
                {
                    GReview = group.review,
                    GGame = game,
                })
                .GroupJoin(_context.Users,
                           review => review.GReview.UserId,
                           user => user.UserId,
                           (review, user) => new
                           {
                               review.GReview,
                               review.GGame,
                               GUsers = user.DefaultIfEmpty()
                           })
                .SelectMany(group => group.GUsers,
                            (group, user) => new GameReviewViewModel
                            {
                                ReviewId = group.GReview.ReviewId,
                                ReviewContent = group.GReview.ReviewText,
                                ReviewGame = group.GGame.Title,
                                Username = user.Username,
                                Score = group.GReview.Score,
                                CreatedAt = group.GReview.CreatedAt
                            })
                .ToList();
            return View(gamingReviews);
        }

        public IActionResult News()
        {
            return View();
        }
    }
}
