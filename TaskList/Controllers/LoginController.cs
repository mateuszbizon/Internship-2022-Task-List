using Helpers.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Interfaces;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost(Name = "Login")]

        public ActionResult Login(LoginRequest loginDto)
        {
            _userService.Login(loginDto);

            return Ok();
        }
    }
}
