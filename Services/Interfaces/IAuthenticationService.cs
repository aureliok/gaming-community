using GamingCommunity.Entities;
namespace GamingCommunity.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string usernameOrEmail, string password);

        bool VerifyPassword(string password, string hashedPassword);
    }
}
