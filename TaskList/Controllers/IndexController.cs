using Helpers.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Storage.Interfaces;
using System.Security.Claims;

namespace TaskList.Controllers
{
    public class IndexController : Controller
    {
        private readonly IUserService _userService;

        public IndexController(IUserService userService)
        {
            _userService = userService;
        }

        //logowanie
        public async Task<IActionResult> Login()
        {
            return View("Login");
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var result = await _userService.Login(login);

            ViewBag.Success = result.success;
            ViewBag.Message = result.message;

            if (result.success)
            {
                //return RedirectToAction("Home", "Home");
                return Ok(result.message);
            }

            return View("Login");
        }

        //rejestracja
        public async Task<IActionResult> Register()
        {
            return View("Register");
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register(RegistrationRequest registration)
        {
            var result = await _userService.CreateUser(registration);

            ViewBag.Success = result.success;
            ViewBag.Message = result.message;

            return View("Register");
        }

        //index
        public async Task<IActionResult> Index()
        {
            return View("Index");
        }
    }
}
