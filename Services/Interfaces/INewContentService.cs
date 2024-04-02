using GamingCommunity.Models;
using GamingCommunity.Repositories.Interfaces;

namespace GamingCommunity.Services.Interfaces
{
    public interface INewContentService
    {
        public Task AddNewReview(NewGameReviewViewModel viewModel, int userId);
        //public Task UpdateNewReview(NewGameReviewViewModel viewModel, int userId);
        //public Task DeleteReview(NewGameReviewViewModel viewModel, int userId);

        public Task AddNewThread(NewGamingThreadViewModel viewModel, int userId);
        //public Task UpdateNewThread(NewGamingThreadViewModel viewModel, int userId);
        //public Task DeleteThread(NewGamingThreadViewModel viewModel, int userId);

        public Task AddNewReply(NewReplyModel viewModel, int userId);

        public Task AddNewVote(VoteInputModel viewModel, int userId);
        public Task AddNewPrivateMessage(SendPrivateMessageModel viewModel, int userId);
    }
}
