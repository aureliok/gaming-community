using GamingCommunity.Models;
using GamingCommunity.Entities;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GamingCommunity.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        
        public AuthenticationController(IAuthenticationService authenticationService, ITokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
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
    }
}
