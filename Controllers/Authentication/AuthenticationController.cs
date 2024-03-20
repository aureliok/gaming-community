using GamingCommunity.Models;
using GamingCommunity.Entities;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using GamingCommunity.Services.Implementations;

namespace GamingCommunity.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        private readonly IUserManagementService _userManagementService;
        
        public AuthenticationController(IAuthenticationService authenticationService, ITokenService tokenService, IUserManagementService userManagementService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
            _userManagementService = userManagementService;
        }

        [HttpGet]
        [Route("Login", Name = "Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("Register", Name = "Register")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        [SwaggerOperation(Summary = "Authenticate user")]
        [SwaggerResponse(200, "Success")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await _authenticationService.AuthenticateAsync(model.UsernameOrEmail, model.Password);

            if (user != null)
            {
                var token = _tokenService.GenerateJwtToken(user.UserId, user.Username);

                Response.Cookies.Append("jwtToken_gcom", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });

                return Ok();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("Logout", Name = "Logout")]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("jwtToken_gcom");

            return RedirectToAction("Login", "Authentication");
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
