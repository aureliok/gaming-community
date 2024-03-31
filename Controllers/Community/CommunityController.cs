using GamingCommunity.Entities;
using GamingCommunity.Models;
using GamingCommunity.Repositories.Implementations;
using GamingCommunity.Repositories.Interfaces;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Authentication;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;

namespace GamingCommunity.Controllers.Community
{
    public class CommunityController : Controller
    {
        private readonly GamingCommunityDbContext _context;
        private readonly INewContentService _newContentService;

        public CommunityController(GamingCommunityDbContext context, 
                                  INewContentService newContentService)
        {
            _context = context;
            _newContentService = newContentService;
        }

        private int GetUserFromClaim()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Claim nameIdentifierClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(nameIdentifierClaim.Value);
            return userId;
        }

        public IActionResult YourProfile()
        {
            return View();
        }

        [HttpGet]
        [Route("/Community/Gaming")]
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
                    CommentsCount = group.Count(x => x.Comment != null)
                })
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return View(gamingThreads);
        }

        [HttpGet]
        [Route("GetCommentsFromThread")]
        public IActionResult GetCommentsFromThread(int threadId)
        {
            try
            {
                List<CommentWithUsernameViewModel> comments = _context.Comments
                    .Where(x => x.ThreadId == threadId)
                    .OrderBy(x => x.CreatedAt)
                    .Join(
                        _context.Users,
                        comment => comment.UserId,
                        user => user.UserId,
                        (comment, user) => new CommentWithUsernameViewModel
                        {
                            CommentId = comment.CommentId,
                            Content = comment.Content,
                            UserId = comment.UserId,
                            CreatedAt = comment.CreatedAt.ToString("M/d/yyyy h:mm:ss tt"),
                            Username = user.Username
                        })
                    .ToList();

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Community/Reviews")]
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
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return View(gamingReviews);
        }

        public IActionResult News()
        {
            return View();
        }


        [HttpPost]
        [Route("NewReview")]
        public async Task<IActionResult> PostNewReview([FromBody] NewGameReviewViewModel newGameReviewViewModel)
        {
            if (newGameReviewViewModel == null)
            {
                return BadRequest();
            }
            int userId = GetUserFromClaim();

            try
            {
                await _newContentService.AddNewReview(newGameReviewViewModel, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("NewThread")]
        public async Task<IActionResult> PostNewThread([FromBody] NewGamingThreadViewModel newGamingThreadViewModel)
        {
            if (newGamingThreadViewModel == null)
            {
                return BadRequest();
            }
            int userId = GetUserFromClaim();

            try
            {
                await _newContentService.AddNewThread(newGamingThreadViewModel, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("NewReply")]
        public async Task<IActionResult> AddNewReply([FromBody] NewReplyModel newReplyModel)
        {
            if (newReplyModel == null || newReplyModel.Content.Length <= 5) return BadRequest();

            int userId = GetUserFromClaim();

            try
            {
                _newContentService.AddNewReply(newReplyModel, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public async Task<IEnumerable<Vote>> GetVotesForContentType(string contentType, IEnumerable<int?> ids)
        {
            if (contentType == "comment")
            {
                return _context.Votes.Where(vote => ids.Contains(vote.CommentId)).ToList();

            } else if (contentType == "review")
            {
                return _context.Votes.Where(vote => ids.Contains(vote.ReviewId)).ToList();

            } else if (contentType == "thread")
            {
                return _context.Votes.Where(vote => ids.Contains(vote.ThreadId)).ToList();
            }

            throw new NotSupportedException(contentType);
        }

        public VoteAggCountViewModel[] GetVoteAggCount(IEnumerable<Vote> votes, string cType)
        {
            if (cType == "comment")
            {
                VoteAggCountViewModel[] votesAgg = votes
                                                .GroupBy(vote => vote.CommentId)
                                                .Select(group => new VoteAggCountViewModel
                                                {
                                                    Id = group.Key,
                                                    ContentType = "comment",
                                                    UpvoteCount = group.Count(vote => vote.VoteType == "upvote"),
                                                    DownvoteCount = group.Count(vote => vote.VoteType == "downvote")
                                                })
                                                .ToArray();

                return votesAgg;

            } else if (cType == "review")
            {
                VoteAggCountViewModel[] votesAgg = votes
                                                .GroupBy(vote => vote.ReviewId)
                                                .Select(group => new VoteAggCountViewModel
                                                {
                                                    Id = group.Key,
                                                    ContentType = "review",
                                                    UpvoteCount = group.Count(vote => vote.VoteType == "upvote"),
                                                    DownvoteCount = group.Count(vote => vote.VoteType == "downvote")
                                                })
                                                .ToArray();

                return votesAgg;

            } else if (cType == "thread")
            {
                VoteAggCountViewModel[] votesAgg = votes
                                                .GroupBy(vote => vote.ThreadId)
                                                .Select(group => new VoteAggCountViewModel
                                                {
                                                    Id = group.Key,
                                                    ContentType = "thread",
                                                    UpvoteCount = group.Count(vote => vote.VoteType == "upvote"),
                                                    DownvoteCount = group.Count(vote => vote.VoteType == "downvote")
                                                })
                                                .ToArray();

                return votesAgg;

            } else
            {
                throw new NotSupportedException();
            }
        }


        [HttpPost]
        [Route("GetVotes")]
        public async Task<IActionResult> GetVotes([FromBody] TupleIdModel[] tupleIds)
        {
            IEnumerable<TupleIdModel> tuplesThread = tupleIds.Where(tuple => tuple.ContentType == "thread");
            IEnumerable<TupleIdModel> tuplesComment = tupleIds.Where(tuple => tuple.ContentType == "comment");
            IEnumerable<TupleIdModel> tuplesReview = tupleIds.Where(tuple => tuple.ContentType == "review");
            IEnumerable<VoteAggCountViewModel> tuplesReturnVotes = Enumerable.Empty<VoteAggCountViewModel>();

            if (tuplesThread.Count() > 0)
            {
                IEnumerable<Vote> votesThread = await GetVotesForContentType("thread", tuplesThread.Select(tuple => tuple.Id));
                VoteAggCountViewModel[] votesAggThread = GetVoteAggCount(votesThread, "thread");

                tuplesReturnVotes = tuplesReturnVotes.Concat(votesAggThread);
            }

            if (tuplesComment.Count() > 0)
            {
                var test = tuplesComment.Select(tuple => tuple.Id);
                IEnumerable<Vote> votesComment = await GetVotesForContentType("comment", tuplesComment.Select(tuple => tuple.Id));
                VoteAggCountViewModel[] votesAggComment = GetVoteAggCount(votesComment, "comment");

                tuplesReturnVotes = tuplesReturnVotes.Concat(votesAggComment);
            }

            if (tuplesReview.Count() > 0)
            {
                IEnumerable<Vote> votesReview = await GetVotesForContentType("review", tuplesReview.Select(tuple => tuple.Id));
                VoteAggCountViewModel[] votesAggReview = GetVoteAggCount(votesReview, "review");

                tuplesReturnVotes = tuplesReturnVotes.Concat(votesAggReview);
            }

            if (tuplesReturnVotes.Any())
            {
                return Ok(tuplesReturnVotes);
            } else
            {
                return BadRequest("No vote data to send");
            }
        }

        [HttpPost]
        [Route("NewVote")]
        public async Task<IActionResult> AddNewVote([FromBody] VoteInputModel voteInputModel)
        {
            if (voteInputModel == null)
                return BadRequest();

            if (voteInputModel.VoteType != "upvote" && voteInputModel.VoteType != "downvote")
                return BadRequest();

            int userId = GetUserFromClaim();

            try
            {
                await _newContentService.AddNewVote(voteInputModel, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
