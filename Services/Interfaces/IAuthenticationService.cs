using GamingCommunity.Entities;

namespace GamingCommunity.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string usernameOrEmail, string password);

        bool VerifyPassword(string password, string hashedPassword);
    }
}
