using Helpers.Requests;
using Microsoft.AspNetCore.Mvc;
using Storage.Interfaces;
using Storage.Models;
using System.Security.Claims;

namespace TaskList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        
        private readonly IGroupService _groupService;

        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger, IGroupService groupService)
        {
            _logger = logger;
            
            _groupService = groupService;
        }

        [HttpPost(Name = "CreateGroup")]

        public ActionResult CreateGroup(GroupRequest group)
        {
            //var userId = Guid.NewGuid; // HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _groupService.CreateGroup(group);


            return Ok();
        }
    }
}
