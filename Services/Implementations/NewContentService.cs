using GamingCommunity.Entities;
using GamingCommunity.Models;
using GamingCommunity.Repositories.Interfaces;
using GamingCommunity.Services.Interfaces;

namespace GamingCommunity.Services.Implementations
{
    public class NewContentService : INewContentService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IGameReviewRepository _gameReviewRepository;
        private readonly IGamingThreadRepository _gameThreadRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IInboxMessageRepository _inboxMessageRepository;
        
        public NewContentService(IGameRepository gameRepository,
                          IDeveloperRepository developerRepository,
                          IPlatformRepository platformRepository,
                          IGameReviewRepository gameReviewRepository,
                          IGamingThreadRepository gamingThreadRepository,
                          IVoteRepository voteRepository,
                          ICommentRepository commentRepository,
                          IInboxMessageRepository inboxMessageRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _platformRepository = platformRepository;
            _gameReviewRepository = gameReviewRepository;
            _gameThreadRepository = gamingThreadRepository;
            _voteRepository = voteRepository;
            _commentRepository = commentRepository;
            _inboxMessageRepository = inboxMessageRepository;
        }

        public async Task AddNewReview(NewGameReviewViewModel viewModel, int userId)
        {
            int gameId = await _gameRepository.GetIdByNameAsync(viewModel.Game);

            if (gameId == -1)
            {
                throw new Exception("The game doesn't exist in the database");
            }

            int platformId = await _platformRepository.GetIdByNameAsync(viewModel.Platform);

            GameReview gameReview = new GameReview
            {
                GameId = gameId,
                PlatformId = platformId,
                UserId = userId,
                Score = viewModel.Score,
                ReviewText = viewModel.Review,
                CreatedAt = DateTime.UtcNow
            };

            await _gameReviewRepository.AddAsync(gameReview);
        }

        public async Task AddNewThread(NewGamingThreadViewModel viewModel, int userId)
        {
            GamingThread gamingThread = new GamingThread
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = userId
            };

            await _gameThreadRepository.AddAsync(gamingThread);
        }

        public async Task AddNewReply(NewReplyModel viewModel, int userId)
        {
            Comment comment = new Comment
            {
                Content = viewModel.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = userId,
                ThreadId = viewModel.ThreadId
            };

            await _commentRepository.AddAsync(comment);
        }

        public async Task AddNewVote(VoteInputModel voteInputModel, int userId)
        {

            Vote vote = new Vote
            {
                VoteType = voteInputModel.VoteType,
                UserId = userId,
                ThreadId = voteInputModel.ThreadId != 0 ? voteInputModel.ThreadId : null,
                CommentId = voteInputModel.CommentId != 0 ? voteInputModel.CommentId : null,
                ReviewId = voteInputModel.ReviewId != 0 ? voteInputModel.ReviewId : null
            };

            await _voteRepository.AddAsync(vote);
        }

        public async Task AddNewPrivateMessage(SendPrivateMessageModel model, int userId)
        {
            InboxMessage inboxMessage = new InboxMessage
            {
                SenderId = userId,
                RecipientId = model.OtherId,
                MessageText = model.Content,
                CreatedAt = DateTime.UtcNow
            };

            await _inboxMessageRepository.AddAsync(inboxMessage);
        }
    }
}
