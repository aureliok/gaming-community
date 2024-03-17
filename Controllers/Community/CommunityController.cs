using GamingCommunity.Models;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GamingCommunity.Controllers.Community
{
    public class CommunityController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public CommunityController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Main()
        {
            return View();
        }

        [HttpPost]
        [Route("RegisterUser", Name = "RegisterUser")]
        [SwaggerOperation(Summary = "Register new user")]
        [SwaggerResponse(200, "Success")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool userWasRegistered = await _userManagementService.RegisterNewUser(model.Username, model.Email, model.Password, model.BirthDate);

            return userWasRegistered ? Ok() : NotFound();
        }

        [HttpPost]
        [Route("DeleteUser")]
        [SwaggerOperation(Summary = "Delete user")]
        [SwaggerResponse(200, "Success")]
        public async Task<IActionResult> DeleteUser([FromBody] string usernameOrEmail)
        {
            if (string.IsNullOrEmpty(usernameOrEmail))
            {
                return BadRequest();
            }

            await _userManagementService.DeleteUser(usernameOrEmail);

            return Ok();
        }

        [HttpPost]
        [Route("CheckIfUsernameExists")]
        public async Task<IActionResult> CheckIfUsernameExists([FromBody] string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest();
            }

            bool usernameExists = await _userManagementService.CheckIfUsernameExists(username);

            return usernameExists ? Ok() : NotFound();
        }

        [HttpPost]
        [Route("CheckIfEmailExists")]
        public async Task<IActionResult> CheckIfEmailExists([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            bool emailExists = await _userManagementService.CheckIfEmailExists(email);

            return emailExists ? Ok() : NotFound();
        }
    }
}
