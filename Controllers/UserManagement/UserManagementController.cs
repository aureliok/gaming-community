using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security;

namespace GamingCommunity.Controllers.UserManagement
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public int GetUserIdFromClaim()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Claim nameIdentifierClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(nameIdentifierClaim.Value);

            return userId;
        }

        public async Task<IActionResult> ChangeEmailRoute([FromBody] string newEmail)
        {
            int userId = GetUserIdFromClaim();

            try
            {
                await _userManagementService.ChangeEmail(userId, newEmail);
                return Ok("Email changed successfully");
            }
            catch (Exception ex) 
            {
                return BadRequest($"Failed to change email: {ex.Message}");
            }
        }

        public async Task<IActionResult> ChangePasswordRoute([FromBody] string newPassword)
        {
            int userId = GetUserIdFromClaim();

            try
            {
                await _userManagementService.ChangePassword(userId, newPassword);
                return Ok("Password changed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to change email: {ex.Message}");
            }
        }

        public async Task<IActionResult> ChangeUsernameRoute([FromBody] string newUsername)
        {
            int userId = GetUserIdFromClaim();

            try
            {
                await _userManagementService.ChangeUsername(userId, newUsername);
                return Ok("Username changed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to change username: {ex.Message}");
            }
        }
    }
}
