using Microsoft.AspNetCore.Mvc;

namespace Restoran_Web.Controllers
{
    public class UserController : Controller
    {
        [Route("/")]
        public IActionResult Login()
        {
            return View();
        }

    }
}
