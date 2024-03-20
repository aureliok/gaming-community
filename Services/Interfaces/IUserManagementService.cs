using Microsoft.AspNetCore.Mvc;

namespace GamingCommunity.Services.Interfaces
{
    public interface IUserManagementService
    {
        Task<bool> RegisterNewUser(string username, string email, string password, DateOnly birthDate);
        Task DeleteUser(string usernameOrEmail);
        Task ChangeUsername(int userId, string newUsername);
        Task ChangePassword(int userId, string newPassword);
        Task ChangeEmail(int userId, string newEmail);
        Task<bool> CheckIfUserExists(string usernameOrEmail);
        Task<bool> CheckIfEmailExists(string email);
        Task<bool> CheckIfUsernameExists(string username);

    }
}
