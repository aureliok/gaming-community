using GamingCommunity.Models;
using GamingCommunity.Repositories.Interfaces;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GamingCommunity.Controllers.Authentication
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        
        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [Route("api/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("api/login")]
        [SwaggerOperation(Summary = "Authenticate user")]
        [SwaggerResponse(200, "Success")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _authenticationService.AuthenticateAsync(model.UsernameOrEmail, model.Password))
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Unauthorized();
            }
        }
    }
}
