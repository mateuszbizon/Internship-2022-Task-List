using Helpers.Requests;
using Microsoft.AspNetCore.Mvc;
using Storage.Interfaces;
using Storage.Models;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost(Name = "CreateUser")]

        public ActionResult CreateUser(UserRequest user)
        {
            _userService.CreateUser(user);

            return Ok();
        }
    }
}