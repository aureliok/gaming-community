using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GamingCommunity.Entities;
using GamingCommunity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using GamingCommunity.Models;

namespace GamingCommunity.Controllers.UserManagement
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _profileRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly INewContentService _newContentService;
        private readonly GamingCommunityDbContext _context;

        public UserManagementController(IUserManagementService userManagementService, 
                                        IUserRepository userRepository,
                                        IUserProfileRepository profileRepository,
                                        IAuthenticationService authenticationService,
                                        INewContentService newContentService,
                                        GamingCommunityDbContext context)
        {
            _userManagementService = userManagementService;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _authenticationService = authenticationService;
            _newContentService = newContentService;
            _context = context;
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


        [HttpGet]
        [Route("UserIncomingMessages")]
        public List<InboxMessageReturnViewModel> GetUserIncomingMessages(int userId)
        {
            List<InboxMessage> ims = _context.InboxMessages
                                                        .Where(im => im.RecipientId == userId)
                                                        .ToList();

            List<InboxMessageReturnViewModel> imvms = ims
                                                .Select(g => new
                                                {
                                                    SenderId = g.SenderId,
                                                    RecipientId = g.RecipientId,
                                                    CreatedAt = g.CreatedAt,
                                                    MessageText = g.MessageText,
                                                    OtherId = g.SenderId == userId ? g.RecipientId : g.SenderId
                                                })
                                                .Join(_context.Users,
                                                im => im.OtherId,
                                                u => u.UserId,
                                                (im, u) => new InboxMessageReturnViewModel
                                                {
                                                    UserId = userId,
                                                    CreatedAt = im.CreatedAt,
                                                    MessageText = im.MessageText,
                                                    OtherId = im.OtherId,
                                                    OtherUsername = u.Username,
                                                    MessageAuthor = u.Username
                                                })
                                                .ToList();

            if (imvms.Any())
            {
                return imvms;
            } 
            else
            {
                throw new NotSupportedException();
            }

        }
        
        [HttpGet]
        [Route("UserOutgoingMessages")]
        public List<InboxMessageReturnViewModel> GetUserOutgoingMessages(int userId)
        {
            //int userId = GetUserIdFromClaim();

            //if (userIdSession != userId) 
            //    return BadRequest("UserId doesn't match");

            List<InboxMessage> ims = _context.InboxMessages
                                    .Where(im => im.SenderId == userId)
                                    //.GroupBy(im => im.RecipientId)
                                    //.Select(g => g.OrderByDescending(im => im.CreatedAt).FirstOrDefault())
                                    .ToList();

            List<InboxMessageReturnViewModel> imvms = ims
                                                .Select(g => new
                                                {
                                                    SenderId = g.SenderId,
                                                    RecipientId = g.RecipientId,
                                                    CreatedAt = g.CreatedAt,
                                                    MessageText = g.MessageText,
                                                    OtherId = g.SenderId == userId ? g.RecipientId : g.SenderId
                                                })
                                                .Join(_context.Users,
                                                im => im.OtherId,
                                                u => u.UserId,
                                                (im, u) => new InboxMessageReturnViewModel
                                                {
                                                    UserId = userId,
                                                    CreatedAt = im.CreatedAt,
                                                    MessageText = im.MessageText,
                                                    OtherId = im.OtherId,
                                                    OtherUsername = u.Username,
                                                    MessageAuthor = "You"
                                                })
                                                .ToList();

            if (imvms.Any())
            {
                return imvms;
            }
            else
            {
                throw new NotSupportedException();
            }
        }


        [HttpGet]
        [Route("GetLastInboxMessages")]
        public IActionResult GetLastInboxMessages()
        {

            int userId = GetUserIdFromClaim();

            //if (userIdSession != userId) 
            //    return BadRequest("UserId doesn't match");

            List<InboxMessageReturnViewModel> inboxIncoming = GetUserIncomingMessages(userId);
            List<InboxMessageReturnViewModel> inboxOutgoing = GetUserOutgoingMessages(userId);

            List<InboxMessageReturnViewModel?> inboxMessages = inboxIncoming
                                                                .Concat(inboxOutgoing)
                                                                .GroupBy(im => im.OtherId)
                                                                .Select(im => im.OrderByDescending(m => m.CreatedAt).FirstOrDefault())
                                                                .ToList();

            
            return Ok(inboxMessages);
        }

        [HttpGet]
        [Route("GetInboxMessages")]
        public IActionResult GetInboxMessages(int otherUserId)
        {
            int userId = GetUserIdFromClaim();

            List<InboxMessageReturnViewModel> inboxIncoming = GetUserIncomingMessages(userId);
            List<InboxMessageReturnViewModel> inboxOutgoing = GetUserOutgoingMessages(userId);

            inboxIncoming = inboxIncoming.Where(m => m.OtherId == otherUserId).ToList();
            inboxOutgoing = inboxOutgoing.Where(m => m.OtherId == otherUserId).ToList();

            List<InboxMessageReturnViewModel> inboxChat = inboxIncoming
                                                            .Concat(inboxOutgoing)
                                                            .OrderBy(m => m.CreatedAt)
                                                            .ToList();


            return Ok(inboxChat);
        }

        [HttpPost]
        [Route("SendPrivateMessage")]
        public async Task<IActionResult> SendPrivateMessage([FromBody] SendPrivateMessageModel sendPrivateMessageModel)
        {
            int userId = GetUserIdFromClaim();

            Console.WriteLine(sendPrivateMessageModel.OtherId);

            await _newContentService.AddNewPrivateMessage(sendPrivateMessageModel, userId);

            return Ok();
        }
 
    }
}
