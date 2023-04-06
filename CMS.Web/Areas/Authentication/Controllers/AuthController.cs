using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Areas.Authentication.Controllers
{
    public class AuthController : Controller
    {
        [Area("Auth")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
