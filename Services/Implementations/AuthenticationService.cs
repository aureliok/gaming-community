using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using GamingCommunity.Services.Interfaces;

namespace GamingCommunity.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AuthenticateAsync(string usernameOrEmail, string password)
        {
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);

            if (user != null  && VerifyPassword(password, user.PasswordHash))
            {
                return true;
            }

            return false;
        }

        public bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
