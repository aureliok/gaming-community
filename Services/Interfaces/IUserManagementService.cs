using Microsoft.AspNetCore.Mvc;

namespace GamingCommunity.Services.Interfaces
{
    public interface IUserManagementService
    {
        Task<bool> RegisterNewUser(string username, string email, string password, DateOnly birthDate);
        Task DeleteUser(string usernameOrEmail);
        void ChangeUsername(string usernameOrEmail, string newUsername);
        void ChangePassword(string usernameOrEmail, string newPassword);
        void ChangeEmail(string usernameOrEmail, string newEmail);
        Task<bool> CheckIfUserExists(string usernameOrEmail);
        Task<bool> CheckIfEmailExists(string email);
        Task<bool> CheckIfUsernameExists(string username);

    }
}
