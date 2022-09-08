using Helpers.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Storage.Interfaces;
using System.Security.Claims;
using TaskList.Responses;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IndexController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<IndexController> _logger;

        public IndexController(ILogger<IndexController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        //logowanie
        //public async Task<IActionResult> Login()
        //{
        //    return View("Login");
        //}

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var result = await _userService.Login(login);

            var json = new LoginResponse()
            {
                Success = result.success,
                Message = result.message,
            };

            return Ok(JsonConvert.SerializeObject(json));
        }

        //rejestracja
        //public async Task<IActionResult> Register()
        //{
        //    return View("Register");
        //}

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest registration)
        {
            var result = await _userService.CreateUser(registration);

            var json = new RegisterResponse()
            {
                Success = result.success,
                Message = result.message
            };

            return Ok(JsonConvert.SerializeObject(json));
        }

        //index
        //public async Task<IActionResult> Index()
        //{
        //    return View("Index");
        //}
    }
}
