using GamingCommunity.Entities;
namespace GamingCommunity.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string usernameOrEmail, string password);
        Task<User> AuthenticateAsync(int userId, string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
