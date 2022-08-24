using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            ViewBag.userEmail = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            //ViewBag.userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);

            return View("Home");
        }
    }
}
