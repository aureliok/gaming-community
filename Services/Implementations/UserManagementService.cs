using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingCommunity.Services.Implementations
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public UserManagementService(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            _userRepository = userRepository;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<bool> CheckIfUserExists(string usernameOrEmail)
        {
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
                 
            return user != null;
        }

        public async Task<bool> CheckIfUsernameExists(string username)
        {
            User user = await _userRepository.GetByUsernameAsync(username);

            return user != null;
        }

        public async Task<bool> CheckIfEmailExists(string email)
        {
            User user = await _userRepository.GetByEmailAsync(email);

            return user != null;
        }


        public async Task<bool> RegisterNewUser(string username, string email, string password, DateOnly birthDate)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User()
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
            };

            await _userRepository.AddAsync(user);


            UserProfile profile = new UserProfile()
            {
                UserId = user.UserId,
                BirthDate = birthDate,
            };

            await _userProfileRepository.AddAsync(profile);
           

            return true;
        }

        public async Task DeleteUser(string usernameOrEmail)
        {
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
            await _userRepository.DeleteAsync(user.UserId);
        }

        public async Task ChangeUsername(int userId, string newUsername)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            user.Username = newUsername;
            await _userRepository.UpdateAsync(user);
        }

        public async Task ChangePassword(int userId, string newPassword)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            User user = await _userRepository.GetByIdAsync(userId);
            user.PasswordHash = passwordHash;

            await _userRepository.UpdateAsync(user);
        }

        public async Task ChangeEmail(int userId, string newEmail)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            user.Email = newEmail;

            await _userRepository.UpdateAsync(user);
        }
    }
}
