using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Home()
        {
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ViewBag.userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);

            return Ok(userEmail);
        }
    }
}
