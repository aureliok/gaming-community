using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;

namespace GamingCommunity.Controllers.UserManagement
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _profileRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserManagementController(IUserManagementService userManagementService, 
                                        IUserRepository userRepository,
                                        IUserProfileRepository profileRepository,
                                        IAuthenticationService authenticationService)
        {
            _userManagementService = userManagementService;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _authenticationService = authenticationService;
        }

        public int GetUserIdFromClaim()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Claim nameIdentifierClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(nameIdentifierClaim.Value);

            return userId;
        }

        [HttpGet]
        [Route("GetUserData")]
        public async Task<IActionResult> GetUserData()
        {
            int userId = GetUserIdFromClaim();

            if (userId == null)
            {
                return NotFound();
            } 
            else 
            {
                User user = await _userRepository.GetByIdAsync(userId);
                UserProfile profile = await _profileRepository.GetByIdAsync(userId);

                return Json(new
                {
                    username = user.Username,
                    email = user.Email,
                    gender = profile.Gender,
                    birthDate = profile.BirthDate,
                    platformLink = profile.GamingPlatformLink,
                    bio = profile.Bio
                });
            }
        }



        [HttpPost]
        [Route("ChangeEmail")]
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

        [HttpPost]
        [Route("CheckCurrentPassword")]
        public async Task<IActionResult> CheckCurrentPassword([FromBody] string currPassword)
        {
            int userId = GetUserIdFromClaim();

            User user = await _authenticationService.AuthenticateAsync(userId, currPassword);

            if (user == null)
            {
                return NotFound();
            } else
            {
                return Ok();
            }
        }

        [HttpPatch]
        [Route("ChangePassword")]
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
                return BadRequest($"Failed to change password: {ex.Message}");
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
