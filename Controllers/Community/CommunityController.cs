using GamingCommunity.Models;
using GamingCommunity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GamingCommunity.Controllers.Community
{
    public class CommunityController : Controller
    {

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult YourProfile()
        {
            return View();
        }
    }
}
