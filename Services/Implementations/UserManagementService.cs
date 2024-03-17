using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingCommunity.Services.Implementations
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository _userRepository;

        public UserManagementService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            //bool existUsername = await CheckIfUserExists(username);
            //bool existEmail = await CheckIfEmailExists(email);

            //if (existUsername || existEmail)
            //{
            //    return false;
            //}

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            User user = new User()
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                BirthDate = birthDate
            };

            await _userRepository.AddAsync(user);

            return true;
        }

        public async Task DeleteUser(string usernameOrEmail)
        {
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
            await _userRepository.DeleteAsync(user.UserId);
        }

        public async void ChangeUsername(string usernameOrEmail, string newUsername)
        {
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
            user.Username = newUsername;
            await _userRepository.UpdateAsync(user);
        }

        public async void ChangePassword(string usernameOrEmail, string newPassword)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
            user.PasswordHash = passwordHash;

            await _userRepository.UpdateAsync(user);
        }

        public async void ChangeEmail(string usernameOrEmail, string newEmail)
        {
            User user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
            user.Email = newEmail;

            await _userRepository.UpdateAsync(user);
        }
    }
}
