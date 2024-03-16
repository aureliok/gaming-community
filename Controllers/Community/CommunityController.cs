using Microsoft.AspNetCore.Mvc;

namespace GamingCommunity.Controllers.Community
{
    public class CommunityController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
